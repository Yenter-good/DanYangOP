using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;

namespace CIS.Utility
{
    /// <summary>
    /// 实体绑定集合
    /// 用于过滤
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public class BindingListView<T> : BindingList<T>, IBindingListView, ITypedList
    {
        private List<PropertyComparer<T>> comparers;
        private FilterHandler<T> mFilterHandler;
        private string mFilterString = string.Empty;
        [NonSerialized]
        private PropertyDescriptorCollection properties;
        private ArrayList unfilteredItems = new ArrayList();
        public BindingListView()
        {            // Get the 'shape' of the list.       
            // Only get the public properties marked with Browsable = true.
            PropertyDescriptorCollection pdc = TypeDescriptor.GetProperties(
                typeof(T),
                new Attribute[]          
                {  
                    new BrowsableAttribute(true)     
                });
            // Sort the properties.        

            properties = pdc.Sort();
        }
        public BindingListView(IList<T> list)
            : base(list)
        {
            // Get the 'shape' of the list. 
            // Only get the public properties marked with Browsable = true.   
            PropertyDescriptorCollection pdc = TypeDescriptor.GetProperties(typeof(T),
                new Attribute[]                
                {                  
                    new BrowsableAttribute(true)     
                });
            // Sort the properties.   
            properties = pdc.Sort();
        }
        #region Sorting
        private bool isSorted;
        private ListSortDirection sortDirection;
        [NonSerialized]
        private PropertyDescriptor sortProperty;
        protected override bool IsSortedCore
        {
            get { return isSorted; }
        }
        protected override bool SupportsSortingCore
        {
            get { return true; }
        }
        protected override ListSortDirection SortDirectionCore
        {
            get { return sortDirection; }
        }
        protected override PropertyDescriptor SortPropertyCore
        {
            get { return sortProperty; }
        }
        protected override void ApplySortCore(PropertyDescriptor property, ListSortDirection direction)
        {
            List<T> items = Items as List<T>;
            if (items != null)
            {
                PropertyComparer<T> pc = new PropertyComparer<T>(property, direction);
                items.Sort(pc);
                isSorted = true;
            }
            else
            {
                isSorted = false;
            }
            sortProperty = property;
            sortDirection = direction;
            OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }
        protected override void RemoveSortCore()
        {
            isSorted = false;
            OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }
        #endregion
        #region Searching
        protected override bool SupportsSearchingCore
        {
            get { return true; }
        }
        protected override int FindCore(PropertyDescriptor property, object key)
        {
            // Specify search columns   
            if (property == null) return -1;
            // Get list to search         
            List<T> items = Items as List<T>;
            // Traverse list for value          
            if (items != null)
            {
                foreach (T item in items)
                {
                    // Test column search value        
                    string value = property.GetValue(item).ToString();
                    // If value is the search value, return the                
                    // index of the data item                
                    if (key.ToString() == value) return IndexOf(item);
                }
            }
            return -1;
        }
        #endregion
        #region IBindingListView 成员
        [NonSerialized]
        private ListSortDescriptionCollection _sorts;
        public void ApplySort(ListSortDescriptionCollection sorts)
        {
            // Get list to sort       
            // Note: this.Items is a non-sortable ICollection<T>    
            List<T> items = Items as List<T>;
            // Apply and set the sort, if items to sort       
            if (items != null)
            {
                _sorts = sorts;
                comparers = new List<PropertyComparer<T>>();
                foreach (ListSortDescription sort in sorts)
                    comparers.Add(new PropertyComparer<T>(sort.PropertyDescriptor, sort.SortDirection));
                items.Sort(CompareValuesByProperties);
            }
            OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }
        /// <summary>
        /// 设置过滤的数据值
        /// </summary>
        public string Filter
        {
            get { return mFilterString; }
            set
            {
                bool Include = false;
                if (string.IsNullOrEmpty(mFilterString))
                {
                    unfilteredItems.Clear();
                    unfilteredItems.AddRange((ICollection)Items);
                }
                Clear();
                if (string.IsNullOrEmpty((string)value))
                {
                    foreach (T item in unfilteredItems)
                        Add(item);
                }
                else
                {
                    foreach (T item in unfilteredItems)
                    {
                        if (mFilterHandler != null)
                        {
                            Include = mFilterHandler.Invoke((string)value, item);
                            if (Include) Add(item);
                        }
                    }
                }
                mFilterString = value;
            }
        }
        public void RemoveFilter()
        {
            Clear();
            foreach (T item in unfilteredItems)
            {
                Add(item);
            }
            unfilteredItems.Clear();
        }
        public ListSortDescriptionCollection SortDescriptions
        {
            get { return _sorts; }
            set { _sorts = value; }

        }
        public bool SupportsAdvancedSorting
        {
            get { return true; }
        }
        public bool SupportsFiltering
        {
            //get { return true; }          
            get { return true; }
        }
        #endregion
        /// <summary>
        /// 过滤的方法
        /// </summary>
        public FilterHandler<T> FilterMethod
        {
            set
            {
                mFilterHandler = value;
                Filter = "";

            }
        }
        private int CompareValuesByProperties(T x, T y)
        {
            if (x == null)
                return (y == null) ? 0 : -1;
            if (y == null)
                return 1;
            foreach (PropertyComparer<T> comparer in comparers)
            {
                int retval = comparer.Compare(x, y);
                if (retval != 0)
                    return retval;
            }
            return 0;
        }

        #region ITypedList 成员
        public PropertyDescriptorCollection GetItemProperties(PropertyDescriptor[] listAccessors)
        {
            PropertyDescriptorCollection pdc;
            if (null == listAccessors)
            {
                // Return properties in sort order.      
                pdc = properties;
            }
            else
            {
                // Return child list shape.       
                pdc = ListBindingHelper.GetListItemProperties(listAccessors[0].PropertyType);
            }
            return pdc;
        }
        // This method is only used in the design-time framework  
        // and by the obsolete DataGrid control.       
        public string GetListName(PropertyDescriptor[] listAccessors)
        {
            return typeof(T).Name;
        }
        #endregion
    }
    public class PropertyComparer<T> : IComparer<T>
    {
        private ListSortDirection _direction;
        private PropertyDescriptor _property;
        public PropertyComparer(PropertyDescriptor property, ListSortDirection direction)
        {
            _property = property;
            _direction = direction;
        }
        /// <summary>     
        /// 比较方法      
        /// </summary>    
        ///  <param name="x">相对属性x</param>  
        /// <param name="y">相对属性y</param>
        /// <returns></returns>    
        #region IComparer<T>
        public int Compare(T xWord, T yWord)
        {
            // Get property values     
            object xValue = GetPropertyValue(xWord, _property.Name);
            object yValue = GetPropertyValue(yWord, _property.Name);
            // Determine sort order        
            if (_direction == ListSortDirection.Ascending)
            {
                return CompareAscending(xValue, yValue);
            }
            return CompareDescending(xValue, yValue);
        }
        public bool Equals(T xWord, T yWord)
        {
            return xWord.Equals(yWord);
        }
        public int GetHashCode(T obj)
        {
            return obj.GetHashCode();
        }
        #endregion
        // Compare two property values of any type    
        private int CompareAscending(object xValue, object yValue)
        {
            int result;
            // If values implement IComparer     
            if (xValue is IComparable)
            {
                result = ((IComparable)xValue).CompareTo(yValue);
            }
            // If values don't implement IComparer but are equivalent     
            else if (xValue == null || xValue.Equals(yValue))
            {
                result = 0;
            }
            // Values don't implement IComparer and are not equivalent, so compare as string values    
            else
                result = xValue.ToString().CompareTo(yValue.ToString());
            // Return result        
            return result;
        }
        private int CompareDescending(object xValue, object yValue)
        {
            // Return result adjusted for ascending or descending sort order ie    
            // multiplied by 1 for ascending or -1 for descending     
            return CompareAscending(xValue, yValue) * -1;
        }
        private object GetPropertyValue(T value, string property)
        {
            // Get property     
            PropertyInfo propertyInfo = value.GetType().GetProperty(property);
            // Return value          
            return propertyInfo.GetValue(value, null);
        }
    }
    /// <summary>
    /// 过滤委托
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="FilterValue">过滤的数据值</param>
    /// <param name="Item">当前项目</param>
    /// <returns>返回是否过滤</returns>
    public delegate bool FilterHandler<T>(string FilterValue, T Item);
}

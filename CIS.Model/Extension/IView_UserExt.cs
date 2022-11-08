namespace CIS.Model
{
    partial class IView_User
    {
        /// <summary>
        /// 获取人员类型
        /// </summary>
        public PersonType PersonType
        {
            get
            {
                return IView_User.ToPersonType(this.Type);
            }
        }
        /// <summary>
        /// 转换为人员类型
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static PersonType ToPersonType(string type)
        {
            switch (type)
            {
                case "1":
                    return Model.PersonType.Doctor;
                case "2":
                    return Model.PersonType.Nurse;
                case "3":
                    return Model.PersonType.Finance;
                case "99":
                    return Model.PersonType.Other;
                default:
                    return Model.PersonType.Other;
            }
        }
    }
}

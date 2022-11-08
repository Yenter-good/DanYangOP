select deptname as 科室名称,doctorname as 医生姓名,count(1) as 接诊人次,count(id) as 病历数量
,count(id)*1.0/(case when count(1)=0 then 1 else count(1) end) as 病历比例
,count(主诉)*1.0/(case when count(id)=0 then 1 else count(id) end) as 主诉
,count(现病史)*1.0/(case when count(id)=0 then 1 else count(id) end) as 现病史
,count(体格检查)*1.0/(case when count(id)=0 then 1 else count(id) end) as 体格检查
,count(既往史)*1.0/(case when count(id)=0 then 1 else count(id) end) as 既往史
,count(个人史)*1.0/(case when count(id)=0 then 1 else count(id) end) as 个人史
,count(吸烟史)*1.0/(case when count(id)=0 then 1 else count(id) end) as 吸烟史
,count(婚育史)*1.0/(case when count(id)=0 then 1 else count(id) end) as 婚育史
,count(家族史)*1.0/(case when count(id)=0 then 1 else count(id) end) as 家族史
,count(过敏史)*1.0/(case when count(id)=0 then 1 else count(id) end) as 过敏史
,count(药敏史)*1.0/(case when count(id)=0 then 1 else count(id) end) as 药敏史
 from (
select deptname,doctorname,outpatientno,b.id,b.ChiefComplaints as 主诉,b.PresentIllness as 现病史,b.Past as 既往史,b.Personal as 个人史,b.PhysicalExamination as 体格检查, 
b.Smoke as 吸烟史,b.Marrital as 婚育史,b.Family as 家族史,b.Allergen as 过敏史,b.DrugAllergy as 药敏史
from (select doctorno,deptname,doctorname,outpatientno from op_journal WHERE UpdateDate>='{0}' and UpdateDate <'{1}' union all select doctorno,deptname,doctorname,outpatientno from op_journal_history WHERE UpdateDate>='{0}' and UpdateDate <'{1}') a
left join (SELECT * FROM DBO.OP_MEDICALRECORDS WHERE UPDATETIME>='{0}' and UPDATETIME <'{1}' UNION ALL SELECT * FROM DBO.OP_MEDICALRECORDS_HISTORY WHERE UPDATETIME>='{0}' and UPDATETIME <'{1}' ) b on a.outpatientno=b.TreatmentNo AND A.DOCTORNO=B.USERID 
) a group by deptname,doctorname
order by deptname,doctorname
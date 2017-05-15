// ------------------------------------------------------------------------------
//    Copyright (C) 成都联宇创新科技有限公司 版权所有。 
//    
//    文件名：Queue.cs
//    文件功能描述：
//    创建标识：吴来伟 2017/04/24
//    
//    修改标识：
//    修改描述：
// ------------------------------------------------------------------------------


using System;
using Dapper;

namespace NancyService.Model
{

    /// <summary>
    /// There are no comments for NancyService.Model.Queue, NancyService.Model in the schema.
    /// </summary>
    [Table("Queue")]
    public class Queue
    {

    
        /// <summary>
        /// There are no comments for Id in the schema.
        /// </summary>
        [Property("Id",KeyType =KeyType.Identity)]
        public virtual int Id {  get; set;}

    
        /// <summary>
        /// There are no comments for Code in the schema.
        /// </summary>
        [Property("Code")]
        public virtual string Code {  get; set;}

    
        /// <summary>
        /// There are no comments for Description in the schema.
        /// </summary>
        [Property("Description")]
        public virtual string Description {  get; set;}

    
        /// <summary>
        /// There are no comments for Starttime in the schema.
        /// </summary>
        [Property("StartTime")]
        public virtual DateTime? Starttime {  get; set;}

    
        /// <summary>
        /// There are no comments for Endtime in the schema.
        /// </summary>
        [Property("EndTime")]
        public virtual DateTime? Endtime {  get; set;}

    
        /// <summary>
        /// There are no comments for Count in the schema.
        /// </summary>
        [Property("Count")]
        public virtual int? Count {  get; set;}
    }

}

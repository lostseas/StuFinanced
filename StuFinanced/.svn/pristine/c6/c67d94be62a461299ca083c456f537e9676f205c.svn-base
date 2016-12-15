using StuFinanced.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StuFinanced.BLL
{
    public class BaseBLL<T> where T : class,new()
    {
        BaseDAL<T> baseDal = new DAL.BaseDAL<T>();

        #region 1.0 添加实体
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns></returns>
        public int Add(T model)
        {
            return baseDal.Add(model);
        }
        #endregion

        #region 2.0 删除实体
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="model">删除对象</param>
        /// <returns></returns>
        public int Del(T model)
        {
            return baseDal.Del(model);
        }
        #endregion

        #region 2.1 根据条件删除
        /// <summary>
        /// 根据条件删除
        /// </summary>
        /// <param name="delWhere">删除条件</param>
        /// <returns></returns>
        public int DelBy(Expression<Func<T, bool>> delWhere)
        {

            return baseDal.DelBy(delWhere);
        }
        #endregion

        #region 3.0 修改实体
        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="param">参数</param>
        /// <returns></returns>
        public int Modify(T model, params string[] param)
        {
            return baseDal.Modify(model, param);
        }
        #endregion

        #region 3.1 根据条件修改
        /// <summary>
        /// 条件修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="whereLambda">条件</param>
        /// <param name="modifiedProName">参数</param>
        /// <returns></returns>
        public int ModifyBy(T model, Expression<Func<T, bool>> whereLambda, params string[] modifiedProName)
        {
            return baseDal.ModifyBy(model, whereLambda, modifiedProName);
        }
        #endregion

        #region 4.0 根据条件查询
        /// <summary>
        /// 根据条件查询
        /// </summary>
        /// <param name="whereLambda">查询条件</param>
        /// <returns></returns>
        public List<T> GetListBy(Expression<Func<T, bool>> whereLambda)
        {
            return baseDal.GetListBy(whereLambda);
        }
        #endregion

        #region 4.1 根据条件查询 排序
        /// <summary>
        ///  根据条件查询 排序
        /// </summary>
        /// <typeparam name="TKey">排序属性</typeparam>
        /// <param name="whereLambda">查询条件</param>
        /// <param name="orderLambda">排序条件</param>
        /// <returns></returns>
        public List<T> GetListBy<TKey>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, TKey>> orderLambda, bool orderType)
        {
            return baseDal.GetListBy(whereLambda, orderLambda, orderType);
        }
        #endregion

        #region 4.2 根据条件查询 排序 分页

        /// <summary>
        /// 根据条件查询 排序 分页
        /// </summary>
        /// <typeparam name="TKey">排序属性</typeparam>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页数量</param>
        /// <param name="wherelambda">查询条件</param>
        /// <param name="orderLambda">排序条件</param>
        /// <returns></returns>
        public List<T> GetListBy<TKey>(int pageIndex, int pageSize, Expression<Func<T, bool>> whereLambda, Expression<Func<T, TKey>> orderLambda, bool orderType, out int totalCount)
        {
            return baseDal.GetListBy(pageIndex, pageSize, whereLambda, orderLambda, orderType, out totalCount);
        }
        #endregion
    }
}

using Bocasay.Data.Dto.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bocasay.Data.JsonFile.Base
{
	public interface IJsonBase<T> where T : BaseDto
	{
		/// <summary>
		/// Get all datas
		/// </summary>
		/// <returns></returns>
		IEnumerable<T> GetAll();

		/// <summary>
		/// Get object by id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		T GetbyId(Guid id);

		/// <summary>
		/// Add a object
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		bool Add(T data);

		/// <summary>
		/// Add many object
		/// </summary>
		/// <param name="datas"></param>
		/// <returns></returns>
		bool Add(IEnumerable<T> datas);

		/// <summary>
		/// Update a obkect that exist
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		bool Update(T data);

		/// <summary>
		/// Delete a obkect that exist
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		bool Delete(Guid id);

		/// <summary>
		/// Save all change
		/// </summary>
		/// <returns></returns>
		bool SaveChange();
	}
}

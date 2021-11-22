using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wedeliver.Application.ViewModels;

namespace wedeliver.Application.Extensions
{
    public static class PaginationExtension
    {
        /// <summary>
        /// Gets the pagination.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query">The query.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="isDescending">if set to <c>true</c> [is descending].</param>
        /// <returns></returns>
        public static async Task<PaginationVM<T>> Paginate<T>(this IQueryable<T> query, int? page = 1, int? pageSize = 50)
        {
            if (page == null || pageSize == null || page == 0 || pageSize == 0)
            {
                page = 1;
                pageSize = 50;
            }

            var totalItems = await query.CountAsync();

            if (page.HasValue && pageSize.HasValue)
                query = query
                    .Skip((page.Value - 1) * pageSize.Value)
                    .Take(pageSize.Value);

            var displayCount = await query.CountAsync();
            var displayStart = (page == 1) && (displayCount > 0) ? 1 : (page > 1) ? (((int)page - 1) * (int)pageSize) + (((int)pageSize) == 1 ? 0 : 1) : 0;
            var displayEnd = (displayCount > 0) ? displayStart + displayCount - 1 : displayStart;
            var numOfPages = GetNumberOfPage(totalItems, (int)pageSize);
            List<T> results = await query.ToListAsync();

            return new PaginationVM<T>
            {
                TotalItems = totalItems,
                PageSize = pageSize,
                NumberOfPages = numOfPages,
                Page = page,
                DisplayCount = displayCount,
                DisplayStart = displayStart,
                DisplayEnd = displayEnd,
                Results = results,
            };
        }

        /// <summary>
        /// Converts the specified pagination to another type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="pagination">The pagination.</param>
        /// <param name="viewModels">The view models.</param>
        /// <returns></returns>
        public static PaginationVM<TResult> ToPaginatedViewModel<T, TResult>(this PaginationVM<T> pagination, List<TResult> viewModels)
        {
            return new PaginationVM<TResult>
            {
                TotalItems = pagination.TotalItems,
                Page = pagination.Page,
                NumberOfPages = pagination.NumberOfPages,
                PageSize = pagination.PageSize,
                Results = viewModels
            };
        }

        /// <summary>
        /// Get Number Of Page
        /// </summary>
        /// <param name="totalItems"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        private static int GetNumberOfPage(int totalItems, int pageSize)
        {
            bool isOnePage = totalItems <= pageSize;
            var nunOfFullPages = (int)(totalItems / pageSize);
            var itemsbalance = (int)(totalItems % pageSize);
            var numOfPages = (isOnePage) ? 1 : nunOfFullPages + ((itemsbalance > 0) ? 1 : 0);

            return numOfPages;
        }

        public static async Task<PaginationVM<T>> PaginateAsync<T>(this IQueryable<T> query, int? page = 1, int? pageSize = 50)
        {
            if (page == null || pageSize == null || page == 0 || pageSize == 0)
            {
                page = 1;
                pageSize = 50;
            }
            int totalItems = await query.CountAsync();
            if (page.HasValue && pageSize.HasValue)
                query = query
                    .Skip((page.Value - 1) * pageSize.Value)
                    .Take(pageSize.Value);

            int displayCount = await query.CountAsync();
            int displayStart = (page == 1) && (displayCount > 0) ? 1 : (page > 1) ? (((int)page - 1) * (int)pageSize) + (((int)pageSize) == 1 ? 0 : 1) : 0;
            int displayEnd = (displayCount > 0) ? displayStart + displayCount - 1 : displayStart;
            int numOfPages = GetNumberOfPage(totalItems, (int)pageSize);
            List<T> results = await query.ToListAsync();

            return new PaginationVM<T>
            {
                TotalItems = totalItems,
                PageSize = pageSize,
                NumberOfPages = numOfPages,
                Page = page,
                DisplayCount = displayCount,
                DisplayStart = displayStart,
                DisplayEnd = displayEnd,
                Results = results,
            };
        }
    }
}

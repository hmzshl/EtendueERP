using System;
using System.Data;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Components;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Radzen;

using EtendueERP.Data;

namespace EtendueERP
{
    public partial class EtendueERPService
    {
        EtendueERPContext Context
        {
           get
           {
             return this.context;
           }
        }

        private readonly EtendueERPContext context;
        private readonly NavigationManager navigationManager;

        public EtendueERPService(EtendueERPContext context, NavigationManager navigationManager)
        {
            this.context = context;
            this.navigationManager = navigationManager;
        }

        public void Reset() => Context.ChangeTracker.Entries().Where(e => e.Entity != null).ToList().ForEach(e => e.State = EntityState.Detached);


        public async Task ExportTTauxesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/etendueerp/ttauxes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/etendueerp/ttauxes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTTauxesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/etendueerp/ttauxes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/etendueerp/ttauxes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTTauxesRead(ref IQueryable<EtendueERP.Models.EtendueERP.TTaux> items);

        public async Task<IQueryable<EtendueERP.Models.EtendueERP.TTaux>> GetTTauxes(Query query = null)
        {
            var items = Context.TTauxes.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnTTauxesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTTauxGet(EtendueERP.Models.EtendueERP.TTaux item);

        public async Task<EtendueERP.Models.EtendueERP.TTaux> GetTTauxById(int id)
        {
            var items = Context.TTauxes
                              .AsNoTracking()
                              .Where(i => i.id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnTTauxGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTTauxCreated(EtendueERP.Models.EtendueERP.TTaux item);
        partial void OnAfterTTauxCreated(EtendueERP.Models.EtendueERP.TTaux item);

        public async Task<EtendueERP.Models.EtendueERP.TTaux> CreateTTaux(EtendueERP.Models.EtendueERP.TTaux ttaux)
        {
            OnTTauxCreated(ttaux);

            var existingItem = Context.TTauxes
                              .Where(i => i.id == ttaux.id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.TTauxes.Add(ttaux);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(ttaux).State = EntityState.Detached;
                throw;
            }

            OnAfterTTauxCreated(ttaux);

            return ttaux;
        }

        public async Task<EtendueERP.Models.EtendueERP.TTaux> CancelTTauxChanges(EtendueERP.Models.EtendueERP.TTaux item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTTauxUpdated(EtendueERP.Models.EtendueERP.TTaux item);
        partial void OnAfterTTauxUpdated(EtendueERP.Models.EtendueERP.TTaux item);

        public async Task<EtendueERP.Models.EtendueERP.TTaux> UpdateTTaux(int id, EtendueERP.Models.EtendueERP.TTaux ttaux)
        {
            OnTTauxUpdated(ttaux);

            var itemToUpdate = Context.TTauxes
                              .Where(i => i.id == ttaux.id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(ttaux);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTTauxUpdated(ttaux);

            return ttaux;
        }

        partial void OnTTauxDeleted(EtendueERP.Models.EtendueERP.TTaux item);
        partial void OnAfterTTauxDeleted(EtendueERP.Models.EtendueERP.TTaux item);

        public async Task<EtendueERP.Models.EtendueERP.TTaux> DeleteTTaux(int id)
        {
            var itemToDelete = Context.TTauxes
                              .Where(i => i.id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTTauxDeleted(itemToDelete);


            Context.TTauxes.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTTauxDeleted(itemToDelete);

            return itemToDelete;
        }
        }
}
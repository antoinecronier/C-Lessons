﻿using App1.Model.Base;
using SQLite.Net;
using SQLiteNetExtensions.Extensions;
using System;
using System.Collections.Generic;
using Windows.Storage;

namespace App1
{
    public class SQLiteManager2<T> : SQLiteConnection where T : EntityBase
    {
        public SQLiteManager2() : base(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(),
            ApplicationData.Current.LocalFolder.Path + "\\SQLiteDB")
        {
            try
            {
                //this.DropTable<T>();
                this.CreateTable<T>();
            }
            catch (Exception)
            {
                this.MigrateTable<T>();
            }
        } 

        public void Inserteu(T item)
        {
            this.Insert(item);
            //this.InsertOrReplace(item);
        }

        public void InsertAll(List<T> items)
        {
            this.InsertAllWithChildren(items);
        }

        public void Insert1(T item)
        {
            this.InsertOrReplaceWithChildren(item);
        }

        public void Insert2(T item)
        {
            this.InsertWithChildren(item);
        }

        public T Get(T item)
        {
            return this.Get<T>(item.Id);
        }

        public T Get(int id)
        {
            return this.Get<T>(id);
        }

        public T GetWithChildrenHeu(int id)
        {
            //var result = this.Get(id);
            //this.GetChildren(result);
            //return this.FindWithChildren<T>(id);
            return this.GetWithChildren<T>(id,true);
            //return result;
        }

        public List<T> Get(List<T> items)
        {
            List<T> result = new List<T>();
            foreach (var item in items)
            {
                result.Add(this.Get(item));
            }
            return result;
        }

        public List<T> Get(List<int> items)
        {
            List<T> result = new List<T>();
            foreach (var item in items)
            {
                result.Add(this.Get(item));
            }
            return result;
        }
    }
}

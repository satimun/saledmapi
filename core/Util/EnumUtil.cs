﻿using Core.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace core.Util
{
    public static class EnumUtil
    {

        public static string GetDisplayName<T>(this T enumVal)
             where T : struct, IComparable, IFormattable, IConvertible
        {
            if (!typeof(T).IsEnum) throw new Exception("ไม่ใช่ประเภทข้อมูล Enum.");
            return AttributeUtil.GetAttributeOfType<DisplayAttribute>(enumVal).Name;
        }
        public static string GetDisplayName<T>(string strVal)
             where T : struct, IComparable, IFormattable, IConvertible
        {
            int val = (int)strVal[0];
            object e = Enum.ToObject(typeof(T), val);
            return AttributeUtil.GetAttributeOfType<DisplayAttribute>((T)e).Name;
        }

        public static string GetDescription<T>(this T enumVal)
             where T : struct, IComparable, IFormattable, IConvertible
        {
            if (!typeof(T).IsEnum) throw new Exception("ไม่ใช่ประเภทข้อมูล Enum.");
            return AttributeUtil.GetAttributeOfType<DisplayAttribute>(enumVal).Description;
        }

        public static object GetEnum<T>(this char c) where T : struct, IComparable, IFormattable, IConvertible
        {
            int val = (int)c;
            return Enum.ToObject(typeof(T), val);
        }

        //public static Attribute GetEnum<T>(this T enumVal)
        //     where T : struct, IComparable, IFormattable, IConvertible
        //{
        //    if (!typeof(T).IsEnum) throw new Exception("ไม่ใช่ประเภทข้อมูล Enum.");
        //    return AttributeUtil.GetAttributeOfType<DisplayAttribute>(enumVal);
        //}

        public static T GetEnum<T>(this T code)
        {
            var list = Enum.GetValues(typeof(T)).Cast<T>().ToList();
            return (T)list.Where(x => x.ToString() == code.ToString()).FirstOrDefault();
        }

        public static T GetEnum<T>(this string code)
        {
            var list = Enum.GetValues(typeof(T)).Cast<T>().ToList();
            return (T)list.Where(x => x.ToString() == code).FirstOrDefault();
        }

        //public static string GetName<T>()
        //{
        //    return typeof(T).GetEnumName().ToString()
        //}


        public static List<KeyValuePair<string, char>> ListKeyValuesChar<T>() where T : struct, IComparable, IFormattable, IConvertible
        {
            List<KeyValuePair<string, char>> res = new List<KeyValuePair<string, char>>();
            ListKeyValuesInt<T>().ForEach(x => res.Add(new KeyValuePair<string, char>(x.Key, (char)x.Value)));
            return res;
        }

        // create by SoMRuk 26/12/2017
        public static List<KeyValuePair<string, string>> ListKeyValuesString<T>() where T : struct, IComparable, IFormattable, IConvertible
        {
            List<KeyValuePair<string, string>> res = new List<KeyValuePair<string, string>>();
            ListKeyValuesInt<T>().ForEach(x => res.Add(new KeyValuePair<string, string>(x.Key, ((char)x.Value).ToString())));
            return res;
        }

        //// create by SoMRuk 15/5/2018
        public class objAttr
        {
            public int Value { get; set; }
            public string GroupName { get; set; }
            public string Prompt { get; set; }
            public string Description { get; set; }
            public string Name { get; set; }
            public string ShortName { get; set; }
            public int Order { get; set; }

        }

        // create by SoMRuk 15/5/2018
        public static List<objAttr> ListAttr<T>() where T : struct, IComparable, IFormattable, IConvertible
        {
            if (!typeof(T).IsEnum) throw new Exception("ไม่ใช่ประเภทข้อมูล Enum.");
            List<T> list = Enum.GetValues(typeof(T)).Cast<T>().ToList<T>();
            List<objAttr> res = new List<objAttr>();
            foreach (T e in list)
            {
                DisplayAttribute attr = AttributeUtil.GetAttributeOfType<DisplayAttribute>(e);
                objAttr tmp = new objAttr();
                res.Add(tmp);
                tmp.Name = attr.Name;
                tmp.GroupName = attr.GroupName;
                tmp.Prompt = attr.Prompt;
                tmp.Description = attr.Description;
                tmp.ShortName = attr.ShortName;
                tmp.Order = attr.Order;


                if (string.IsNullOrWhiteSpace(attr.Name)) continue;
                tmp.Value = (int)Enum.Parse(typeof(T), e.ToString());
            }
            return res./*OrderBy(x => x.Order).*/ToList();
        }

        public static List<T> List<T>() where T : struct, IComparable, IFormattable, IConvertible
        {
            if (!typeof(T).IsEnum) throw new Exception("ไม่ใช่ประเภทข้อมูล Enum.");
            return Enum.GetValues(typeof(T)).Cast<T>().ToList<T>();
        }

        public static List<KeyValuePair<string, int>> ListKeyValuesInt<T>() where T : struct, IComparable, IFormattable, IConvertible
        {
            if (!typeof(T).IsEnum) throw new Exception("ไม่ใช่ประเภทข้อมูล Enum.");
            List<T> list = Enum.GetValues(typeof(T)).Cast<T>().ToList<T>();
            List<KeyValuePair<int, KeyValuePair<string, int>>> displayAttr = new List<KeyValuePair<int, KeyValuePair<string, int>>>();
            List<KeyValuePair<string, int>> res = new List<KeyValuePair<string, int>>();
            foreach (T e in list)
            {
                DisplayAttribute attr = AttributeUtil.GetAttributeOfType<DisplayAttribute>(e);
                string key = EnumUtil.GetDisplayName<T>(e);
                if (string.IsNullOrWhiteSpace(key)) continue;
                int val = (int)Enum.Parse(typeof(T), e.ToString());
                displayAttr.Add(new KeyValuePair<int, KeyValuePair<string, int>>(attr.Order,
                    new KeyValuePair<string, int>(key, val)));
            }
            res = displayAttr.OrderBy(x => x.Key).Select(x => x.Value).ToList();
            return res;
        }
        public static string GetValueString<T>(this T enumVal)
             where T : struct, IComparable, IFormattable, IConvertible
        {
            return enumVal.GetValueChar().ToString();
        }
        public static char GetValueChar<T>(this T enumVal)
             where T : struct, IComparable, IFormattable, IConvertible
        {
            return (char)enumVal.GetValueInt();
        }
        public static int GetValueInt<T>(this T enumVal)
             where T : struct, IComparable, IFormattable, IConvertible
        {
            return (int)Enum.Parse(typeof(T), enumVal.ToString());
        }
        public static T GetValueEnum<T>(string strVal)
             where T : struct, IComparable, IFormattable, IConvertible
        {
            int val = (int)strVal[0];
            object e = Enum.ToObject(typeof(T), val);
            return (T)e;
        }



        public static List<string> ListValueString<T>()
             where T : struct, IComparable, IFormattable, IConvertible
        {
            List<string> res = ListKeyValuesChar<T>().Select(x => x.Value.ToString()).ToList();
            return res;
        }
        public static List<string> ListValueString<T>(params T[] param)
             where T : struct, IComparable, IFormattable, IConvertible
        {
            List<string> res = new List<string>();
            foreach (T p in param)
            {
                res.Add(GetValueString<T>(p));
            }
            return res;
        }

        public static List<KeyValuePair<string, char>> SortAndConvertKeyValueList<TEnum>(List<TEnum> lis)
             where TEnum : struct, IComparable, IFormattable, IConvertible
        {
            List<KeyValuePair<string, char>> res = new List<KeyValuePair<string, char>>();
            foreach (KeyValuePair<string, char> e in ListKeyValuesChar<TEnum>())
            {
                if (lis.Any(x => x.GetValueString().Equals(e.Value.ToString())))
                    res.Add(e);
            }
            return res;
        }
    }
}

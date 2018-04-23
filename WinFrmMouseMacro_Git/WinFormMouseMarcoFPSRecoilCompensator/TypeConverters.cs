using SharpDX.DirectInput;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;

namespace WinFormMouseMarco
{
    /// <summary>
    /// https://www.cnblogs.com/tianmochou/p/5085898.html
    /// </summary>
    public class CheckboxPro : System.Drawing.Design.UITypeEditor
    {
        public override bool GetPaintValueSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override void PaintValue(System.Drawing.Design.PaintValueEventArgs e)
        {
            ControlPaint.DrawCheckBox(e.Graphics, e.Bounds, ButtonState.Inactive);
        }
    }
    public class MethodInfoConverter : TypeConverter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns>
        /// true enable;
        /// false disable</returns>
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            //return new StandardValuesCollection(new string[] { "男", "女" }); //编辑下拉框中的items

            var slist = new List<string>();
            foreach (var item in context.Instance.GetType().GetMethods())
            {
                if (item.IsPublic && item.IsStatic)
                {
                    slist.Add(item.Name);
                }
            }
            return new StandardValuesCollection(slist);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns>
        /// true: disable text editting.
        /// false: enable text editting;</returns>
        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }
    }
    //internal class KeyConverter : ExpandableObjectConverter
    //{
    //    public override object ConvertTo(ITypeDescriptorContext context,
    //                              System.Globalization.CultureInfo culture,
    //                              object value, Type destType)
    //    {
    //        if (destType == typeof(string) && value is Key)
    //        {
    //            var emp = (Key)value;
    //            //return emp.Department + "," + emp.Role;
    //            return value.ToString();
    //        }
    //        return base.ConvertTo(context, culture, value, destType);
    //    }
    //}


    [TypeConverter(typeof(KeyMacroBindingConverter))]//[TypeConverter(typeof(ExpandableObjectConverter))]
    public class KeyMacroBinding
    {
        [Editor(typeof(CheckboxPro),typeof(System.Drawing.Design.UITypeEditor))]
        [TypeConverter(typeof(PublicInstanceStaticMacroActionConverter))]  //使用自定义的属性下拉item类
        public Action Action { get; set; }
        public Key Hotkey { get; set; }
        //public System.Windows.Forms.Keys Hotkey { get; set; }
    }
    internal class KeyMacroBindingConverter : ExpandableObjectConverter
    {
        public static string ConvertToString(KeyMacroBinding v)
        {
            var strHK = "";
            switch (v.Hotkey)
            {
                case Key.Unknown:
                    break;
                default:
                    strHK = v.Hotkey.ToString();
                    break;
            }
            var strMethod = "No Action";
            switch (v.Action)
            {
                case null:
                    break;
                default:
                    strMethod = v.Action.Method.Name;
                    break;
            }
            return $"[{strHK}]-{strMethod}";
        }
        public override object ConvertTo(ITypeDescriptorContext context,
                                  System.Globalization.CultureInfo culture,
                                  object value, Type destType)
        {
            if (destType == typeof(string) && value is KeyMacroBinding)
            {
                //var emp = (KeyMacroBinding)value;
                //return emp.Department + "," + emp.Role;
                //return emp.Hotkey.ToString();
                return ConvertToString((KeyMacroBinding)value);
            }
            return base.ConvertTo(context, culture, value, destType);
        }
    }
    /// <summary>
    /// https://www.codeproject.com/Articles/4448/Customized-display-of-collection-data-in-a-Propert
    /// </summary>
    public class KeyMacroBindingCollection : CollectionBase, ICustomTypeDescriptor
    {
        // Collection methods

        public void Add(KeyMacroBinding emp)
        {
            this.List.Add(emp);
        }
        public void Remove(KeyMacroBinding emp)
        {
            this.List.Remove(emp);
        }
        public KeyMacroBinding this[int index]
        {
            get
            {
                return (KeyMacroBinding)this.List[index];
            }
        }
        // Implementation of ICustomTypeDescriptor:

        public String GetClassName()
        {
            return TypeDescriptor.GetClassName(this, true);
        }

        public AttributeCollection GetAttributes()
        {
            return TypeDescriptor.GetAttributes(this, true);
        }

        public String GetComponentName()
        {
            return TypeDescriptor.GetComponentName(this, true);
        }

        public TypeConverter GetConverter()
        {
            return TypeDescriptor.GetConverter(this, true);
        }

        public EventDescriptor GetDefaultEvent()
        {
            return TypeDescriptor.GetDefaultEvent(this, true);
        }

        public PropertyDescriptor GetDefaultProperty()
        {
            return TypeDescriptor.GetDefaultProperty(this, true);
        }

        public object GetEditor(Type editorBaseType)
        {
            return TypeDescriptor.GetEditor(this, editorBaseType, true);
        }

        public EventDescriptorCollection GetEvents(Attribute[] attributes)
        {
            return TypeDescriptor.GetEvents(this, attributes, true);
        }

        public EventDescriptorCollection GetEvents()
        {
            return TypeDescriptor.GetEvents(this, true);
        }

        public object GetPropertyOwner(PropertyDescriptor pd)
        {
            return this;
        }
        public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        {
            return GetProperties();
        }

        public PropertyDescriptorCollection GetProperties()
        {
            // Create a new collection object PropertyDescriptorCollection
            var pds = new PropertyDescriptorCollection(null);

            // Iterate the list of employees
            for (int i = 0; i < this.List.Count; i++)
            {
                // For each employee create a property descriptor 
                // and add it to the 
                // PropertyDescriptorCollection instance
                KeyMacroBindingCollectionPropertyDescriptor pd = new KeyMacroBindingCollectionPropertyDescriptor(this, i);
                pds.Add(pd);
            }
            return pds;
        }
    }
    public class KeyMacroBindingCollectionPropertyDescriptor : PropertyDescriptor
    {
        private KeyMacroBindingCollection collection = null;
        private int index = -1;

        public KeyMacroBindingCollectionPropertyDescriptor(KeyMacroBindingCollection coll,
                           int idx) : base("#" + idx.ToString(), null)
        {
            this.collection = coll;
            this.index = idx;
        }

        public override AttributeCollection Attributes
        {
            get
            {
                return new AttributeCollection(null);
            }
        }

        public override bool CanResetValue(object component)
        {
            return true;
        }

        public override Type ComponentType
        {
            get
            {
                return this.collection.GetType();
            }
        }

        public override string DisplayName
        {
            get
            {
                //KeyMacroBinding emp = this.collection[index];
                //return emp.FirstName + " " + emp.LastName;
                //return emp.Method?.Name + "<=" + emp.Hotkey;
                return $"{index}-{KeyMacroBindingConverter.ConvertToString(this.collection[index])}";
            }
        }

        public override string Description
        {
            get
            {
                KeyMacroBinding emp = this.collection[index];
                var sb = new System.Text.StringBuilder();
                //sb.Append(emp.LastName);
                //sb.Append(",");
                //sb.Append(emp.FirstName);
                //sb.Append(",");
                //sb.Append(emp.Age);
                //sb.Append(" years old, working for ");
                //sb.Append(emp.Department);
                //sb.Append(" as ");
                //sb.Append(emp.Role);

                //sb.Append($"Method:{emp.Method?.Name}, Key:{emp.Hotkey}");

                var item = emp.Action;
                if (item!=null)
                {
                    var arro = item.Method.GetCustomAttributes(typeof(DescriptionAttribute), false);
                    if (arro != null && arro.Length > 0)
                    {
                        sb.Append((arro[0] as DescriptionAttribute).Description);
                    }
                }
                else
                {
                    sb.Append("do nothing");
                }

                return sb.ToString();
            }
        }

        public override object GetValue(object component)
        {
            return this.collection[index];
        }

        public override bool IsReadOnly
        {
            get { return true; }
        }

        public override string Name
        {
            get { return "#" + index.ToString(); }
        }

        public override Type PropertyType
        {
            get { return this.collection[index].GetType(); }
        }

        public override void ResetValue(object component) { }

        public override bool ShouldSerializeValue(object component)
        {
            return true;
        }

        public override void SetValue(object component, object value)
        {
            // this.collection[index] = value;
        }
    }



    [TypeConverter(typeof(MouseMacroBindingConverter))]
    public class MouseMacroBinding
    {
        [TypeConverter(typeof(StaticActionConverter<DefaultMacroController>))]
        public Action Action { get; set; }
        public int Button { get; set; }
    }
    internal class MouseMacroBindingConverter : ExpandableObjectConverter
    {
        public static string ConvertToString(MouseMacroBinding v)
        {
            var strHK = "";
            switch (v.Button)
            {
                case 0:
                    strHK = "LMB";
                    break;
                case 1:
                    strHK = "MMB";
                    break;
                case 2:
                    strHK = "RMB";
                    break;
                default:
                    strHK = $"Button[{v.Button}]";
                    break;
            }
            var strMethod = "No Action";
            switch (v.Action)
            {
                case null:
                    break;
                default:
                    strMethod = v.Action.Method.Name;
                    break;
            }
            return $"[{strHK}]-{strMethod}";
        }
        public override object ConvertTo(ITypeDescriptorContext context,
                                  System.Globalization.CultureInfo culture,
                                  object value, Type destType)
        {
            if (destType == typeof(string) && value is MouseMacroBinding)
            {
                //var emp = (MouseMacroBinding)value;
                //return emp.Department + "," + emp.Role;
                return MouseMacroBindingConverter.ConvertToString((MouseMacroBinding)value);
            }
            return base.ConvertTo(context, culture, value, destType);
        }
    }
    public class MouseMacroBindingCollection : CollectionBase, ICustomTypeDescriptor
    {
        // Collection methods

        public void Add(MouseMacroBinding emp)
        {
            this.List.Add(emp);
        }
        public void Remove(MouseMacroBinding emp)
        {
            this.List.Remove(emp);
        }
        public MouseMacroBinding this[int index]
        {
            get
            {
                return (MouseMacroBinding)this.List[index];
            }
        }
        // Implementation of ICustomTypeDescriptor:

        public String GetClassName()
        {
            return TypeDescriptor.GetClassName(this, true);
        }

        public AttributeCollection GetAttributes()
        {
            return TypeDescriptor.GetAttributes(this, true);
        }

        public String GetComponentName()
        {
            return TypeDescriptor.GetComponentName(this, true);
        }

        public TypeConverter GetConverter()
        {
            return TypeDescriptor.GetConverter(this, true);
        }

        public EventDescriptor GetDefaultEvent()
        {
            return TypeDescriptor.GetDefaultEvent(this, true);
        }

        public PropertyDescriptor GetDefaultProperty()
        {
            return TypeDescriptor.GetDefaultProperty(this, true);
        }

        public object GetEditor(Type editorBaseType)
        {
            return TypeDescriptor.GetEditor(this, editorBaseType, true);
        }

        public EventDescriptorCollection GetEvents(Attribute[] attributes)
        {
            return TypeDescriptor.GetEvents(this, attributes, true);
        }

        public EventDescriptorCollection GetEvents()
        {
            return TypeDescriptor.GetEvents(this, true);
        }

        public object GetPropertyOwner(PropertyDescriptor pd)
        {
            return this;
        }
        public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        {
            return GetProperties();
        }

        public PropertyDescriptorCollection GetProperties()
        {
            // Create a new collection object PropertyDescriptorCollection
            var pds = new PropertyDescriptorCollection(null);

            // Iterate the list of employees
            for (int i = 0; i < this.List.Count; i++)
            {
                // For each employee create a property descriptor 
                // and add it to the 
                // PropertyDescriptorCollection instance
                MouseMacroBindingCollectionPropertyDescriptor pd = new MouseMacroBindingCollectionPropertyDescriptor(this, i);
                pds.Add(pd);
            }
            return pds;
        }
    }
    public class MouseMacroBindingCollectionPropertyDescriptor : PropertyDescriptor
    {
        private MouseMacroBindingCollection collection = null;
        private int index = -1;

        public MouseMacroBindingCollectionPropertyDescriptor(MouseMacroBindingCollection coll,
                           int idx) : base("#" + idx.ToString(), null)
        {
            this.collection = coll;
            this.index = idx;
        }

        public override AttributeCollection Attributes
        {
            get
            {
                return new AttributeCollection(null);
            }
        }

        public override bool CanResetValue(object component)
        {
            return true;
        }

        public override Type ComponentType
        {
            get
            {
                return this.collection.GetType();
            }
        }

        public override string DisplayName
        {
            get
            {
                //MouseMacroBinding emp = this.collection[index];
                //return emp.FirstName + " " + emp.LastName;
                //return emp.Method?.Name + "<=" + emp.Hotkey;
                return $"{index}-{MouseMacroBindingConverter.ConvertToString(this.collection[index])}";
            }
        }

        public override string Description
        {
            get
            {
                MouseMacroBinding v = this.collection[index];
                var sb = new System.Text.StringBuilder();

                var strMethod = "No Action";
                switch (v.Action)
                {
                    case null:
                        break;
                    default:
                        strMethod = v.Action.Method.Name;
                        break;
                }

                sb.Append($"Method:{strMethod}, Key:{v.Button}");

                return sb.ToString();
            }
        }

        public override object GetValue(object component)
        {
            return this.collection[index];
        }

        public override bool IsReadOnly
        {
            get { return true; }
        }

        public override string Name
        {
            get { return "#" + index.ToString(); }
        }

        public override Type PropertyType
        {
            get { return this.collection[index].GetType(); }
        }

        public override void ResetValue(object component) { }

        public override bool ShouldSerializeValue(object component)
        {
            return true;
        }

        public override void SetValue(object component, object value)
        {
            // this.collection[index] = value;
        }
    }


    public class StaticActionConverter : TypeConverter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns>
        /// true enable;
        /// false disable</returns>
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        System.Reflection.BindingFlags mBFlags = System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static;
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            var slist = new List<string>();
            var t = context.Instance.GetType();
            foreach (var item in t.GetMethods(mBFlags))
            {
                slist.Add(item.Name);
            }
            return new StandardValuesCollection(slist);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns>
        /// true: disable text editting.
        /// false: enable text editting;</returns>
        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }

        public override object ConvertTo(ITypeDescriptorContext context,
                                  System.Globalization.CultureInfo culture,
                                  object value, Type destType)
        {
            if (destType == typeof(string) && value is Action)
            {
                return (value as Action).Method.Name;
            }
            return base.ConvertTo(context, culture, value, destType);
        }
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
            {
                return true;
            }
            return base.CanConvertFrom(context, sourceType);
        }
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is string)
            {
                var t = context.Instance.GetType();
                var mi = t.GetMethod(value as string, mBFlags);
                if (mi != null)
                {
                    return mi.CreateDelegate(typeof(Action));
                }
            }
            return base.ConvertFrom(context, culture, value);
        }
    }
    public class StaticActionConverter<T> : TypeConverter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns>
        /// true enable;
        /// false disable</returns>
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        System.Reflection.BindingFlags mBFlags = System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static;
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            var slist = new List<string>();
            var t = typeof(T);
            foreach (var item in t.GetMethods(mBFlags))
            {
                //if (item.IsPublic && item.IsStatic)
                //{
                //}
                slist.Add(item.Name);
            }
            return new StandardValuesCollection(slist);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns>
        /// true: disable text editting.
        /// false: enable text editting;</returns>
        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }

        public override object ConvertTo(ITypeDescriptorContext context,
                                  System.Globalization.CultureInfo culture,
                                  object value, Type destType)
        {
            if (destType == typeof(string) && value is Action)
            {
                return (value as Action).Method.Name;
            }
            return base.ConvertTo(context, culture, value, destType);
        }
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
            {
                return true;
            }
            return base.CanConvertFrom(context, sourceType);
        }
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is string)
            {
                var t = typeof(T);
                var mi = t.GetMethod(value as string, mBFlags);
                if (mi != null)
                {
                    return mi.CreateDelegate(typeof(Action));
                }
            }
            return base.ConvertFrom(context, culture, value);
        }
    }
    public class InstanceActionConverter : TypeConverter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns>
        /// true enable;
        /// false disable</returns>
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
        System.Reflection.BindingFlags mBFlags = System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance;
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            var slist = new List<string>();
            var t = context.Instance.GetType(); //typeof(T);
            foreach (var item in t.GetMethods(mBFlags))
            {
                slist.Add(item.Name);
            }
            return new StandardValuesCollection(slist);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns>
        /// true: disable text editting.
        /// false: enable text editting;</returns>
        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }

        public override object ConvertTo(ITypeDescriptorContext context,
                                  System.Globalization.CultureInfo culture,
                                  object value, Type destType)
        {
            if (destType == typeof(string) && value is Action)
            {
                return (value as Action).Method.Name;
            }
            return base.ConvertTo(context, culture, value, destType);
        }
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
            {
                return true;
            }
            return base.CanConvertFrom(context, sourceType);
        }
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is string)
            {
                var t = context.Instance.GetType();
                var mi = t.GetMethod(value as string, mBFlags);
                if (mi != null)
                {
                    return mi.CreateDelegate(typeof(Action), context.Instance);
                }
            }
            return base.ConvertFrom(context, culture, value);
        }
    }
    public class PublicInstanceStaticMacroActionConverter : TypeConverter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns>
        /// true enable;
        /// false disable</returns>
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
        System.Reflection.BindingFlags mBFlags = System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Instance;
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            var slist = new List<string>();
            var t = context.Instance.GetType(); //typeof(T);
            foreach (var method1 in t.GetMethods(mBFlags))
            {
                var arro = method1.GetCustomAttributes(typeof(MacroActionAttribute), false);
                if (arro != null && arro.Length > 0)
                {
                }
                else
                {
                    continue;
                }
                slist.Add(method1.Name);
            }
            return new StandardValuesCollection(slist);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns>
        /// true: disable text editting.
        /// false: enable text editting;</returns>
        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }

        public override object ConvertTo(ITypeDescriptorContext context,
                                  System.Globalization.CultureInfo culture,
                                  object value, Type destType)
        {
            if (destType == typeof(string) && value is Action)
            {
                return (value as Action).Method.Name;
            }
            return base.ConvertTo(context, culture, value, destType);
        }
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
            {
                return true;
            }
            return base.CanConvertFrom(context, sourceType);
        }
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is string)
            {
                var t = context.Instance.GetType();
                var method1 = t.GetMethod(value as string, mBFlags);
                if (method1 == null)
                {
                }
                else if (method1.IsStatic)
                {
                    return method1.CreateDelegate(typeof(Action)) as Action;
                }
                else
                {
                    return method1.CreateDelegate(typeof(Action), context.Instance) as Action;
                }
            }
            return base.ConvertFrom(context, culture, value);
        }
    }

    public class DisplayNameAbleConverter : ExpandableObjectConverter
    {
        public static string CustomConvertToString(object instance)
        {
            var arro = instance.GetType().GetCustomAttributes(typeof(DisplayNameAttribute), false);
            if (arro != null && arro.Length > 0)
            {
                return (arro[0] as DisplayNameAttribute).DisplayName;
            }
            else
            {
                return null;
            }
        }
        public override object ConvertTo(ITypeDescriptorContext context,
                                  System.Globalization.CultureInfo culture,
                                  object value, Type destType)
        {
            if (destType == typeof(string))
            {
                var s = CustomConvertToString(value);
                if (!string.IsNullOrEmpty(s))
                {
                    return s;
                }
            }
            return base.ConvertTo(context, culture, value, destType);
        }
    }
}

﻿using System.Collections;
using System.Security;

namespace SDK.Lib
{
    public class UtilXml
    {
        public const int XML_OK = 0;
        public const int XML_FAIL = 1;

        static public int getXmlAttrBool(SecurityElement attr, string name, ref bool ret)
        {
            if (attr != null && attr.Attributes.ContainsKey(name))
            {
                if (UtilApi.TRUE == attr.Attribute(name))
                {
                    ret = true;
                }
                else if (UtilApi.FALSE == attr.Attribute(name))
                {
                    ret = false;
                }
                else
                {
                    ret = false;
                }

                return XML_OK;
            }

            ret = false;
            return XML_FAIL;
        }

        static public int getXmlAttrStr(SecurityElement attr, string name, ref string ret)
        {
            if (attr != null && attr.Attributes.ContainsKey(name))
            {
                ret =  attr.Attribute(name);
                return XML_OK;
            }

            ret = "";
            return XML_FAIL;
        }

        static public int getXmlAttrUShort(SecurityElement attr, string name, ref ushort ret)
        {
            if (attr != null && attr.Attributes.ContainsKey(name))
            {
                ushort.TryParse(attr.Attribute(name), out ret);
                return XML_OK;
            }

            ret = 0;
            return XML_FAIL;
        }

        static public int getXmlAttrInt(SecurityElement attr, string name, ref short ret)
        {
            if (attr != null && attr.Attributes.ContainsKey(name))
            {
                short.TryParse(attr.Attribute(name), out ret);
                return XML_OK;
            }

            ret = 0;
            return XML_FAIL;
        }

        static public int getXmlAttrUInt(SecurityElement attr, string name, ref uint ret)
        {
            if (attr != null && attr.Attributes.ContainsKey(name))
            {
                uint.TryParse(attr.Attribute(name), out ret);
                return XML_OK;
            }

            ret = 0;
            return XML_FAIL;
        }

        static public int getXmlAttrInt(SecurityElement attr, string name, ref int ret)
        {
            if (attr != null && attr.Attributes.ContainsKey(name))
            {
                int.TryParse(attr.Attribute(name), out ret);
                return XML_OK;
            }

            ret = 0;
            return XML_FAIL;
        }

        static public int getXmlAttrFloat(SecurityElement attr, string name, ref float ret)
        {
            if (attr != null && attr.Attributes.ContainsKey(name))
            {
                float.TryParse(attr.Attribute(name), out ret);
                return XML_OK;
            }

            ret = 0;
            return XML_FAIL;
        }

        // 获取一个 Element 中对应名字是 name 的孩子节点列表
        static public int getXmlChildList(SecurityElement elem, string name, ref ArrayList list)
        {
            if (elem != null)
            {
                int idx = 0;
                int len = elem.Children.Count;
                SecurityElement child = null;

                //foreach (SecurityElement child in elem.Children)
                while(idx < len)
                {
                    child = elem.Children[idx] as SecurityElement;

                    //比对下是否使自己所需要得节点
                    if (child.Tag == name)
                    {
                        list.Add(child);
                    }

                    ++idx;
                }
            }

            if (list.Count > 0)
            {
                return XML_OK;
            }
            else
            {
                list.Clear();
                return XML_FAIL;
            }
        }

        // 获取一个孩子节点
        static public int getXmlChild(SecurityElement elem, string name, ref SecurityElement childNode)
        {
            if (elem != null)
            {
                int idx = 0;
                int len = elem.Children.Count;
                SecurityElement child = null;

                //foreach (SecurityElement child in elem.Children)
                while(idx < len)
                {
                    child = elem.Children[idx] as SecurityElement;

                    //比对下是否使自己所需要得节点
                    if (child.Tag == name)
                    {
                        childNode = child;
                        return XML_OK;
                    }

                    ++idx;
                }
            }

            childNode = null;
            return XML_FAIL;
        }

        // 获取某一个元素的所有 Child 列表
        public static int getXmlElementAllChildList(SecurityElement elem, string itemNode, ref ArrayList list)
        {
            SecurityElement objElem = null;

            if (string.IsNullOrEmpty(itemNode))
            {
                objElem = elem;
            }
            else
            {
                UtilXml.getXmlChild(elem, itemNode, ref objElem);
            }

            list = objElem.Children;

            return XML_OK;
        }
    }
}
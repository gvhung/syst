﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class ProductGroup : ProductCategory
{
	public virtual int ProductGroupID
	{
		get;
		set;
	}

	public virtual string ProductGroupName
	{
		get;
		set;
	}

	public virtual ProductCategory ProductCategory
	{
		get;
		set;
	}

}


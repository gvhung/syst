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

public class Product
{
	public virtual int ProductId
	{
		get;
		set;
	}

	public virtual string ProductName
	{
		get;
		set;
	}

	public virtual ProductGroup productGroup
	{
		get;
		set;
	}

	public virtual ProductCategory productCategory
	{
		get;
		set;
	}

	public virtual Department Department
	{
		get;
		set;
	}

}


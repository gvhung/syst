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

public class ManagerGroupCategory
{
	public virtual ProductCategory ProductCategory
	{
		get;
		set;
	}

	public virtual ProductGroup ProductGroup
	{
		get;
		set;
	}

	public virtual ManagerProduct ManagerProduct
	{
		get;
		set;
	}

	public virtual void CreateCategory()
	{
		throw new System.NotImplementedException();
	}

	public virtual void CreateGroup(ProductCategory productCategory)
	{
		throw new System.NotImplementedException();
	}

	public virtual void CheckWhatToCreate()
	{
		throw new System.NotImplementedException();
	}

}


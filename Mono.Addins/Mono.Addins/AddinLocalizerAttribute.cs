﻿//
// AddinLocalizerAttribute.cs
//
// Author:
//       Matt Ward <matt.ward@xamarin.com>
//
// Copyright (c) 2017 Xamarin Inc. (http://xamarin.com)
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;

namespace Mono.Addins
{
	/// <summary>
	/// Declares a custom localizer for an add-in.
	/// </summary>
	[AttributeUsage (AttributeTargets.Assembly)]
	public class AddinLocalizerAttribute: Attribute
	{
		Type type;
		string typeName;
		string registerId;
		string id;

		/// <summary>
		/// Initializes a new instance of the <see cref="Mono.Addins.AddinLocalizerAttribute"/> class.
		/// </summary>
		public AddinLocalizerAttribute ()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Mono.Addins.AddinLocalizerAttribute"/> class.
		/// </summary>
		/// <param name="id">
		/// The id of the localizer to use.
		/// </param>
		public AddinLocalizerAttribute (string id)
		{
			Id = id;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Mono.Addins.AddinLocalizerAttribute"/> class.
		/// </summary>
		/// <param name='type'>
		/// The type of the localizer. This type must implement the
		/// <see cref="Mono.Addins.Localization.IAddinLocalizerFactory"/> interface.
		/// </param>
		public AddinLocalizerAttribute (Type type)
		{
			Type = type;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Mono.Addins.AddinLocalizerAttribute"/> class.
		/// </summary>
		/// <param name='type'>
		/// The type of the localizer. This type must implement the
		/// <see cref="Mono.Addins.Localization.IAddinLocalizerFactory"/> interface.
		/// </param>
		/// <param name='registerId'>
		/// The ID to register this localizer as to be reusable from other addins.
		/// </param>
		public AddinLocalizerAttribute (Type type, string registerId)
		{
			Type = type;
			RegisterId = registerId;
		}

		/// <summary>
		/// Type of the localizer.
		/// </summary>
		public Type Type {
			get { return type; }
			set { type = value; typeName = type.FullName; id = null; }
		}

		internal string TypeName {
			get { return typeName; }
			set { typeName = value; type = null; id = null; }
		}

		/// <summary>
		/// Gets or sets the identifier to register this localizer on
		/// </summary>
		/// <value>The identifier registration name.</value>
		public string RegisterId {
			get { return registerId; }
			set { registerId = value; }
		}

		/// <summary>
		/// This value is used when there is an existing localizer so we don't have to load everything.
		/// </summary>
		/// <value>The ID of the addin localizer.</value>
		public string Id {
			get { return id; }
			set { id = value; typeName = null; type = null; }
		}
	}
}

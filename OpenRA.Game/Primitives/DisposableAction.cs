﻿#region Copyright & License Information
/*
 * Copyright 2007-2011 The OpenRA Developers (see AUTHORS)
 * This file is part of OpenRA, which is free software. It is made
 * available to you under the terms of the GNU General Public License
 * as published by the Free Software Foundation. For more information,
 * see COPYING.
 */
#endregion

using System;

namespace OpenRA.Primitives
{
	public class DisposableAction : IDisposable
	{
		public DisposableAction(Action onDispose, Action onFinalize)
		{
			this.onDispose = onDispose;
			this.onFinalize = onFinalize;
		}

		Action onDispose;
		Action onFinalize;
		bool disposed;

		public void Dispose()
		{
			if (disposed) return;
			disposed = true;
			onDispose();
			GC.SuppressFinalize(this);
		}

		~DisposableAction()
		{
			onFinalize();
		}
	}
}
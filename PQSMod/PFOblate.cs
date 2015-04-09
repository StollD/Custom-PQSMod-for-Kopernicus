/**
 * Kopernicus Planetary System Modifier
 * Copyright (C) 2014 Bryce C Schroeder (bryce.schroeder@gmail.com), Nathaniel R. Lewis (linux.robotdude@gmail.com)
 * 
 * http://www.ferazelhosting.net/~bryce/contact.html
 * 
 * This library is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public
 * License as published by the Free Software Foundation; either
 * version 3 of the License, or (at your option) any later version.
 *
 * This library is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 * Lesser General Public License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public
 * License along with this library; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston,
 * MA 02110-1301  USA
 * 
 * This library is intended to be used as a plugin for Kerbal Space Program
 * which is copyright 2011-2014 Squad. Your usage of Kerbal Space Program
 * itself is governed by the terms of its EULA, not the license above.
 * 
 * https://kerbalspaceprogram.com
 */

using System;
using UnityEngine;

namespace Kopernicus
{
	namespace Configuration
	{
		namespace ModLoader
		{
			[RequireConfigType(ConfigType.Node)]
			public class PFOblate : ModLoader, IParserEventSubscriber
			{
				// Actual PQS mod we are loading
                private PQSMod_PFOblate _mod;

				void IParserEventSubscriber.Apply(ConfigNode node)
				{
                    _mod.offset = 3600;
                    _mod.power = 2;
                        
				}

				void IParserEventSubscriber.PostApply(ConfigNode node)
				{

				}

                public PFOblate()
				{
					// Create the base mod
                    GameObject modObject = new GameObject("PQSMod_PFOblate");
                    modObject.transform.parent = Utility.Deactivator;
                    _mod = modObject.AddComponent<PQSMod_PFOblate>();
                    base.mod = _mod;
				}
			}

            public class PQSMod_PFOblate : PQSMod
            {
                public double offset;
                public double power = 1.0;
                public PQSMod_PFOblate()
                {
                }

                public override void OnSetup()
                {
                    this.requirements = PQS.ModiferRequirements.MeshCustomNormals;
                }
                public override double GetVertexMaxHeight()
                {
                    return offset;
                }

                public override double GetVertexMinHeight()
                {
                    return offset;
                }

                public override void OnVertexBuildHeight(PQS.VertexBuildData vbData)
                {
                    var hei = Math.Sin(3.14159265358979 * vbData.v);
                    hei = Math.Pow(hei, power);
                    vbData.vertHeight = vbData.vertHeight + hei * offset;
                }
            }
		}
	}
}


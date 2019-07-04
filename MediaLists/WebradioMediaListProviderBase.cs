#region Copyright (C) 2007-2019 Team MediaPortal

/*
    Copyright (C) 2007-2019 Team MediaPortal
    http://www.team-mediaportal.com

    This file is part of MediaPortal 2

    MediaPortal 2 is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    MediaPortal 2 is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with MediaPortal 2. If not, see <http://www.gnu.org/licenses/>.
*/

#endregion

using MediaPortal.UI.Presentation.DataObjects;
using MediaPortal.UiComponents.Media.MediaLists;
using System.Threading.Tasks;
using MediaPortal.Common.Commands;
using Webradio.Helper;

namespace Webradio.MediaLists
{
  public abstract class WebradioMediaListProviderBase : IMediaListProvider
  {
    protected ItemsList _allItems;

    protected WebradioMediaListProviderBase()
    {
      _allItems = new ItemsList();
    }

    public ItemsList AllItems => _allItems;

    public abstract Task<bool> UpdateItemsAsync(int maxItems, UpdateReason updateReason);

    protected ListItem CreateStreamItem(MyStream stream)
    {
      var item = new ListItem { AdditionalProperties = { ["StreamUrl"] = stream.StreamUrls[0].StreamUrl } };
      item.SetLabel("Name", stream.Title);
      return item;
    }
  }
}

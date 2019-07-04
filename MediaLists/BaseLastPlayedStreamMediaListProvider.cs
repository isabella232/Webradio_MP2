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

using MediaPortal.Common.UserProfileDataManagement;
using MediaPortal.UiComponents.Media.MediaLists;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webradio.Helper;
using Webradio.Models;

namespace Webradio.MediaLists
{
  public class BaseLastPlayedStreamMediaListProvider : WebradioMediaListProviderBase
  {
    protected ICollection<MyStream> _lastStreams = new List<MyStream>();

    public override async Task<bool> UpdateItemsAsync(int maxItems, UpdateReason updateReason)
    {
      if (!updateReason.HasFlag(UpdateReason.Forced) && !updateReason.HasFlag(UpdateReason.PlaybackComplete))
        return true;

      //todo
      var ms = MyStreams.Read(StreamlistUpdate.StreamListFile);
      


      _lastStreams.Add(ms.Streams[0]);
      _lastStreams.Add(ms.Streams[1]);
      _lastStreams.Add(ms.Streams[2]);

      lock (_allItems.SyncRoot)
      {
        _allItems.Clear();
        foreach (MyStream stream in _lastStreams)
          _allItems.Add(CreateStreamItem(stream));
      }

      _allItems.FireChange();
      return true;
    }
  }
}

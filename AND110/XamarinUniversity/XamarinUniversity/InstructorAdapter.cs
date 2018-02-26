using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Lang;

namespace XamarinUniversity
{
    public class InstructorAdapter : BaseAdapter<Instructor>, ISectionIndexer
    {
        public List<Instructor> instructors { get; }
        Java.Lang.Object[] sectionHeaders;
        Dictionary<int, int> positionForSectionMap;
        Dictionary<int, int> sectionForPositionMap;

        public InstructorAdapter(List<Instructor> instructors)
        {
            this.instructors = instructors;

            sectionHeaders = SectionIndexerBuilder.BuildSectionHeaders(instructors);
            positionForSectionMap = SectionIndexerBuilder.BuildPositionForSectionMap(instructors);
            sectionForPositionMap = SectionIndexerBuilder.BuildSectionForPositionMap(instructors);
        }

        public override Instructor this[int position] => instructors[position];

        public override int Count => instructors.Count;

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;

            if(view == null)
            {
                var inflater = LayoutInflater.From(parent.Context);
                view = inflater.Inflate(Resource.Layout.InstructorRow, parent, false);

                view.Tag = new ViewHolder()
                {
                    Photo = view.FindViewById<ImageView>(Resource.Id.photoImageView),
                    Name = view.FindViewById<TextView>(Resource.Id.nameTextView),
                    Specialty = view.FindViewById<TextView>(Resource.Id.specialtyTextView)
                };
            }

            var holder = (ViewHolder)view.Tag;

            Stream stream = parent.Context.Assets.Open(instructors[position].ImageUrl);
            holder.Photo.SetImageDrawable(ImageAssetManager.Get(parent.Context, instructors[position].ImageUrl));

            holder.Name.Text = instructors[position].Name;
            holder.Specialty.Text = instructors[position].Specialty;

            return view;
        }

        public Java.Lang.Object[] GetSections()
        {
            return sectionHeaders;
        }

        public int GetPositionForSection(int section)
        {
            return positionForSectionMap[section];
        }

        public int GetSectionForPosition(int position)
        {
            return sectionForPositionMap[position];
        }
    }
}
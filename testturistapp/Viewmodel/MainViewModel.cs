using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using testturistapp.Annotations;
using testturistapp.Common;
using testturistapp.Model;

namespace testturistapp.Viewmodel
{
    class MainViewModel : INotifyPropertyChanged
    {
        private Kategori rosTorv = new Kategori(" Ro's Torv", "Ro's Torv ligger i Roskilde og er et unikt shoppingcenter med fokus på design, kunst og arkitektur. De lyse og smukke omgivelser skaber en stemning og stil, som gør det til en særlig oplevelse at besøge centret.", "ms-appx:///assets/rostorv.jpg", "ms-appx:///assets/RosTorv2.jpg");
        private Kategori vikingeMuseum = new Kategori(" Vikingeskibsmuseum", "Vikingeskibsmuseet i Roskilde er Danmarks museum for skibe, søfart og bådbygningskultur i oldtid og middelalder.", "ms-appx:///assets/vikingemuseet.jpg", "ms-appx:///assets/VikingeMuseet2.jpg");
        private Kategori cafeVivaldi = new Kategori(" Cafe Vivaldi", "I Roskildes 2 hjerter finder du de to Vivaldi Caféer. Caféerne kan du finde på gågaden tæt ved domkirken, og på Ro’s Torv - Roskilde fantastiske shoppingcenter. I caféerne er der lagt vægt på lyse og hyggelige omgivelser, hvor du virkelig føler dig hjemme.", "ms-appx:///assets/vivaldi.jpg", "ms-appx:///assets/CafeVivaldi2.jpg");

        private ObservableCollection<Kategori> kategoriviser;
        static RatingHandler _rating;
        private static Kategori _selectedKategori;
        private RelayCommand _opretRatingCommand;
        private RelayCommand _removeRatingCommand;

      

        public MainViewModel()
        {
            kategoriviser = new ObservableCollection<Kategori>();
            kategoriviser.Add(rosTorv);
            rosTorv.Vurderinger.Add(new Rating("Daniel", "god", "5"));

            kategoriviser.Add(vikingeMuseum);
            vikingeMuseum.Vurderinger.Add(new Rating("Bjarke","flotte skibe", "4"));
            _rating = new RatingHandler(_selectedKategori);

            kategoriviser.Add(cafeVivaldi);
            cafeVivaldi.Vurderinger.Add(new Rating("Ebu Gosling","Total Næver","10"));
            _opretRatingCommand = new RelayCommand(_rating.opretRating);
            _removeRatingCommand = new RelayCommand(_rating.sletRating);
        }

        public ObservableCollection<Kategori> Kategoriviser
        {
            get { return kategoriviser; }
            set { kategoriviser = value; }
        }


        public RatingHandler Rating
        {
            get { return _rating; }
            set { _rating = value; }
        }

        public RelayCommand OpretRatingCommand
        {
            get { return _opretRatingCommand; }
            set { _opretRatingCommand = value; }
        }
        public RelayCommand RemoveRatingCommand
        {
            get { return _removeRatingCommand; }
            set { _removeRatingCommand = value; }
        }
        public Kategori CafeVivaldi
        {
            get { return cafeVivaldi; }
            set { cafeVivaldi = value; }
        }

        public Kategori VikingeMuseum
        {
            get { return vikingeMuseum; }
            set { vikingeMuseum = value; }
        }

        public Kategori RosTorv
        {
            get { return rosTorv; }
            set { rosTorv = value; }
        }

        public static Kategori SelectedKategori
        {
            get { return _selectedKategori; }
            set { _selectedKategori = value;}
        }

        public override string ToString()
        {
            return string.Format("CafeVivaldi: {0}, VikingeMuseum: {1}, RosTorv: {2}", cafeVivaldi, vikingeMuseum, rosTorv);
        }

        #region Notifychanged

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));

            #endregion

        }
    }
}

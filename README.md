# Xamarin
Xamarin project for study classes
Nazwa: Gym Progress  

Aplikacja na systemy Android i UWP. S�u�y ona do kontrolowania trening�w i progressu na si�owni. Aplikacja umo�liwia dodawanie trening�w, �wicze�.
Dodatkowo mo�na wy�wietli� podsumowanie trening�w w formie wykresu.  
**TODO:**
-~~dependency service do UWP~~  
-~~dokonczy� guziki w menu~~  
-~~UI dodawania treningu~~  
-~~UI edytowania treningu~~  
-~~UI statystyk~~  
-~~Modele: trening,cwiczenieSP(seria-powotrzenie)~~  
-~~baza danych z odpowiednimi relacjami~~  
-~~dostosowanie layoutu pod wp�ywem rotacji i skalowania~~    
-~~nawigacja z przekazywaniem wartosci~~  
-~~walidacja danych~~  

**spostrzerzenia:**  
* - aby doda� display allert dla dodawania exercise, musia�bym zrezygnowa� z CommandParameter i robi� allert za po�rednictwem kodu pod widokiem a nie pod ModelWidokiem. Wtedy Walidacja musialaby by� po stronie widoku.  
  
* -szeroko�� kolumn jest ustalona w proporcjach, nie w warto�ciach   
  
* -nie jestem w stanie pobra� listy z bazy danych w klasie odpowiadajacej za menadzera tej baz. Musze to robi� w widok-modelu.(Chodzi o Seed, inicjalizacje nowych danych)  
  
* -by dodac jakies pliki(zdjecia) w androidzie trzeba wrzucic go do drawable, a w UWP bezposrednio w roocie...  
-by pozbyc sie navi baru trzeba w kazdym XAML doda� w Content page odpowiedni kod.  
  
* -By wiedziec czy jeste�my w horizontal czy w portrait nale�y w widoku doda� metode, kt�ra  sprawdza czy szeroko�� jest wi�ksza od wysoko�ci, i wtedy zmieni� odpowiednio UI  
  
* - by korzysta� z pe�nej bazy danych samo sqlite-net pcl nie wystarczy trzeba miec wersje extension  
  
* -UWP ma problem z SQL, z jakiego� powodu  rz�da innej paczki. Rozwi�zanie to prze��czenie na realese.  
  
* -By przekaza� warto�� z jednego viewmodelu Do drugiego, przesy�am w konstruktorze syna, jako parametr viewModel ojca. W metodzie syna przypisuje odpowiedni� warto��viewmodelu ojca  
  
* -chc� korzysta� z Command i bandingowania go, ale wiekszo�� akcji powoduje zmiane aktualnego view, tzn Pop, albo Push. Nie jestem wstanie tego zrobi� z poziomu ModelView. musz� delegowa� najpierw z Widoku, a z widoku Command w ViewModel  

* -UWP w momencie tworzenia nowego treningu, pomimo faktu ze lista z cwiczeniami jest pusta, ma on problem z nieistniej�cym jeszcze objektem exercise w metodzie wysiwetlania informacji(toString). Android niem a tego problemu
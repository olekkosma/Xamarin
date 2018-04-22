# Xamarin
Xamarin project for study classes
Nazwa: Gym Progress  

Aplikacja na systemy Android i UWP. S³u¿y ona do kontrolowania treningów i progressu na si³owni. Aplikacja umo¿liwia dodawanie treningów, æwiczeñ.
Dodatkowo mo¿na wyœwietliæ podsumowanie treningów w formie wykresu.  
**TODO:**
-~~dependency service do UWP~~  
-~~dokonczyæ guziki w menu~~  
-~~UI dodawania treningu~~  
-~~UI edytowania treningu~~  
-~~UI statystyk~~  
-~~Modele: trening,cwiczenieSP(seria-powotrzenie)~~  
-~~baza danych z odpowiednimi relacjami~~  
-~~dostosowanie layoutu pod wp³ywem rotacji i skalowania~~    
-~~nawigacja z przekazywaniem wartosci~~  
-~~walidacja danych~~  

**spostrzerzenia:**  
* - aby dodaæ display allert dla dodawania exercise, musia³bym zrezygnowaæ z CommandParameter i robiæ allert za poœrednictwem kodu pod widokiem a nie pod ModelWidokiem. Wtedy Walidacja musialaby byæ po stronie widoku.  
  
* -szerokoœæ kolumn jest ustalona w proporcjach, nie w wartoœciach   
  
* -nie jestem w stanie pobraæ listy z bazy danych w klasie odpowiadajacej za menadzera tej baz. Musze to robiæ w widok-modelu.(Chodzi o Seed, inicjalizacje nowych danych)  
  
* -by dodac jakies pliki(zdjecia) w androidzie trzeba wrzucic go do drawable, a w UWP bezposrednio w roocie...  
-by pozbyc sie navi baru trzeba w kazdym XAML dodaæ w Content page odpowiedni kod.  
  
* -By wiedziec czy jesteœmy w horizontal czy w portrait nale¿y w widoku dodaæ metode, która  sprawdza czy szerokoœæ jest wiêksza od wysokoœci, i wtedy zmieniæ odpowiednio UI  
  
* - by korzystaæ z pe³nej bazy danych samo sqlite-net pcl nie wystarczy trzeba miec wersje extension  
  
* -UWP ma problem z SQL, z jakiegoœ powodu  rz¹da innej paczki. Rozwi¹zanie to prze³¹czenie na realese.  
  
* -By przekazaæ wartoœæ z jednego viewmodelu Do drugiego, przesy³am w konstruktorze syna, jako parametr viewModel ojca. W metodzie syna przypisuje odpowiedni¹ wartoœæviewmodelu ojca  
  
* -chcê korzystaæ z Command i bandingowania go, ale wiekszoœæ akcji powoduje zmiane aktualnego view, tzn Pop, albo Push. Nie jestem wstanie tego zrobiæ z poziomu ModelView. muszê delegowaæ najpierw z Widoku, a z widoku Command w ViewModel  

* -UWP w momencie tworzenia nowego treningu, pomimo faktu ze lista z cwiczeniami jest pusta, ma on problem z nieistniej¹cym jeszcze objektem exercise w metodzie wysiwetlania informacji(toString). Android niem a tego problemu
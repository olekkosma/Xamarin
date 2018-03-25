# Xamarin
Xamarin project for study classes

More details in documentation >> pdf

**TODO:**
-~dependency service do UWP~~  
-dokonczyæ guziki w menu  
-UI dodawania treningu  
-UI edytowania treningu  
-UI statystyk  
-Modele: trening,cwiczenieSP(seria-powotrzenie)  
-baza danych z odpowiednimi relacjami  
-dostosowanie layoutu pod wp³ywem rotacji i skalowania  
-dodanie jakiœ OnStart,OnSleep i on Resume...  
-nawigacja z przekazywaniem wartosci  
-walidacja danych  

**spostrzerzenia:**  
- aby dodaæ display allert dla dodawania exercise, musia³bym zrezygnowaæ z CommandParameter i robiæ allert za poœrednictwem kodu pod widokiem a nie pod ModelWidokiem. Wtedy Walidacja musialaby byæ po stronie widoku.  
-szerokoœæ kolumn jest ustalona w proporcjach, nie w wartoœciach  
-nie jestem w stanie pobraæ listy z bazy danych w klasie odpowiadajacej za menadzera tej baz. Musze to robiæ w widok-modelu.(Chodzi o Seed, inicjalizacje nowych danych)  
-by dodac jakies pliki(zdjecia) w androidzie trzeba wrzucic go do drawable, a w UWP bezposrednio w roocie...  
-by pozbyc sie navi baru trzeba w kazdym XAML dodaæ w Content page odpowiedni kod.  
-By wiedziec czy jesteœmy w horizontal czy w portrait nale¿y w widoku dodaæ metode, która  sprawdza czy szerokoœæ jest wiêksza od wysokoœci, i wtedy zmieniæ odpowiednio UI  
- by korzystaæ z pe³nej bazy danych samo sqlite-net pcl nie wystarczy trzeba miec wersje extension
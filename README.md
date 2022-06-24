# Gravify
Spotifyfake von Nick und Niko
Spotify -
Mit Hilfe von WPF und c# haben wir einen "Spotifyfake" programmiert. Mit "Gravify" kann man mit dem Button "Songs hinzufügen", mp3 Files zur Bibliothek hinzufügen. Wichtig dabei ist dass die Metadaten ausgelesen werden und der Song titel den selben namen wie die Datei haben muss. Im Songfolder sind schon vorgefertigte Songs hinterlegt. Am Besten und Fehlerfreiesten funktioniert das Programm wenn die Zip "Songfolder" extrahiert wird und dieser Ordner als librarydata variable hinterlegt wird.

Beim Starten des Programms müssen noch 3 Variablen in der Paths Klasse geändert werden.

dataPath beschreibt den Ort wo alle jSON Files abgespeichert und aufgerufen werden
libraryPath beschreibt den Ort wo alle Songs liegen
im CreatePlaylist.cs muss der Path zum gleichen Pfad geändert werden wie datapath nur mit "\playlists.json" hinten hinzugefügt.

Nach dem Starten und hinzufügen von Songs können diese in der Bibliothek oder vorher erstellten Playlists angehört werden. Mit den Buttons links und rechts vom Play button oben rechts können Lieder übersprungen oder nocheinmal angehört werden.

Bei Playlist erstellen kann man einen Namen, eine Beschreibung und bei Bedarf ein Profilbild für die Playlist einrichten. Danach wird die Playlist beim drücken des "Playlsts" Button angezeigt.

Wenn man in der Bibliothek auf die 3 Punkte klickt und auf Add to Playlist klickt kann man auswählen in welche Playlist das Lied hinzugefügt werden soll.
Wenn man dann auf die Playlist in der Playlistansicht klickt werden die hinzugefügten songs dargestellt.

Songs werden immer Respektiv zu ihrem Ort abgespielt. Bedeutet wenn man in einer Playlist Lied X abspielt wird danach das Lied abgespielt was in dieser Playlist danach kommt.

Backlog:
Main screen:
User kann Songs laden, alle songs in der Bibliothek anschauen oder playlists erstellen
bzw. erstellte playlists anschauen


V1:
 Lieder in Bibliothek hinzufügen, check
			Lieder aus Explorer auswählen (mp3 Files)
			Metadaten werden ausgelesen und Songs in objekte gespeichert
			In Liste geladen und als Json gespeichert

 Bibliothek laden (JSON), check
			Durch Knopfdruck wird die Liste der Songs Dargestellt mit
			Metadaten usw

 Playlists erstellen,
			Playlist objekt wird erstellt bzw wird zu bestehender Liste hinzugefügt

 Playlists laden,
			Die Liste wird mit Buttons dargestellt welche gedrückt werden können
			um die Songs in der Playlist anzuschauen

 (Lieder Shufflen,
			in zufälliger reihenfolge werden songs "abgespielt" also angezeigt)
			
Lieder wirklich abspielen
			Pfad des angeklickten liedes wird gesucht
			mp3 wird abgespielt


V2:
 Membership
			Mit membership können einzelne lieder abgespielt werden
 
 Covers von Liedern
			Albumcover wenn das lied abgespielt wird
			(und in der Bibliothek)

 Letztes Lied merken (mit Timestamp)
			wenn das Programm geschlossen wird wird in einer Json File
			vermerkt welches lied man zuletzt abgespielt hat und bei
			welcher Minute man war

 Biliothek sortieren nach Künstler, Alphabet, ...
			mit Button sortieren

 Künstler Profil
			Alle lieder eines Künstlers mit Playlists und Alben

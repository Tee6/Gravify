   M S B A M L   `   `   `  ����B  >Spotify, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:SpotifySpotify  5   	       Spotify.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Spotify     5   	     � Title$  Spotify��5   	   $
��1300��6   $	��700��6&    � 
ResizeMode$ NoResize=�63   .��5	      � .+�5
   
   �� -   5         ��Name$ 	Scrollbar��5
      $��1��6*   $	��700��67   .��5      �� -   5         ��Name$ Banner��5      ���	#FF343434$
��1000��6<   5      �� 5   
   -   5        $ 
Menuleiste��5      $
��1000��6%   .+�5      �� -   5         ��Name$ leftrectangle��5      ���	#FF1A1A1A$��5��6@   
���   �$	��684��6c   $	��246��6p   �� 5      ���	#FF1A1A1A
���   �$��5��68   $	��103��6L   $
��1300��6Y   �� 5      -   5         ��Name$ Gravify��5      $��Gravify��6%   $��36(�67   ���	#FF549159$��34,18,33,564q�6\   $
��Bold"�6r   �� 5      -   5        $��
Bibliothek��5      
�������$��22(�6j    J� RenderTransformOrigin$ 
0.53,-0.35&�6x    �� Left$ 76��6�   
 �� Top$	 108��6�   ��6*   Z� ��6@   Z� 6�   �� 5      -   5        $��	Playlists��5      
�������$��22(�6i   $ 86��6w   $	 146��6�   ��6)   Z� ��6?   Z� 6�   �� 5      -   5        	 ��Name$	 CreatePlaylist��5      $��Playlist erstellen��6-   
�������$��24(�6�   $ 40��6�   $	 184��6�   ��6J   Z� ��6`   Z� 6�   A� 5      
���   �$��959,18,27,15q�6%   $��5��6;   �� 5      -	   5        $	 	LoadSongs��5      $��Songs Laden��6(   
�������$��22(�6~   $ 
0.53,-0.35&�6�   $	 282��6�   $ 30��6�   $��Center=�6�   $	��Top=�6  ��6>   Z� ��6T   Z� 6  r� 5      -
   5        
 r�Name$
 mediaElement1��5      $	��100��62   $	��134��6?   $	 447��6K   $	 170��6]   $
��Left=�6n   $��Center=�6�   �� 5      -   5         ��Name$ playbuttonimage��5      $M��GC:\Users\Nick\Downloads\Gravify-master\Spotify\bin\Debug\playbutton.png��6-   $��80��6�   $��83��6�   $
 1074��6�   $ 10��6�   �� 5      -   5        $ pausebuttonimage��5      $N��HC:\Users\Nick\Downloads\Gravify-master\Spotify\bin\Debug\pausebutton.png��6.   $��80��6�   $��83��6�   $
 1074��6�   $ 10��6�   $y�Hidden=�6�   �� 5      -   5        $ skipbuttonimage��5      $M��GC:\Users\Nick\Downloads\Gravify-master\Spotify\bin\Debug\skipbutton.png��6-   $��80��6�   $��83��6�   $
 1141��6�   $ 12��6�   �� 5      -   5        $ backbuttonimage��5      $M��GC:\Users\Nick\Downloads\Gravify-master\Spotify\bin\Debug\skipbutton.png��6-   $��80��6�   $��83��6�   $
 1006��6�   $ 10��6�   $ 0.5,0.5&�6�   5      5      5      
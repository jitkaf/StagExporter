   M S B A M L   `   `   `  ����  StagExporterWPF    App1.MainPage   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      local
using:App1     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5        N� Title$  Uvodni obrazovka��5      .��5      � $��20q�6   $	��600��6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� $��Zadání informací��6   $��0��6,   $��0��69   $��2��6I   $��36(�6]   $
��Bold"�6k   $��10q�6}   �� 5   
   $��Osobní číslo��6   $
��Wrap=�6(   $��1��6<   $��0��6J   $��10q�6Z   �� 5   
   -   5         ��Name$ osobniCisloTB��5       $��10��6   $��1��6Z   $��1��6h   $��10q�6x   �� 5   
   -   5         ��Name$ 
university��5       �� DisplayMemberPath$ 
NazevSkoly��6N    �� SelectedValuePath$ 
NazevSkoly��6m   $��2��6�   $��2��6�   $��0��6�   $��10q�6�   �� 5   
   -   5         ��Name$ chbHarmonogram��5   8   $!��Zahrnout harmonogram školy��6   $��3��6�   $��2��6�   $��0��6�   $��10q�6�   �� 5   
   $��
Kalendář��6   $
��Wrap=�6$   $��4��68   $��0��6F   $��10q�6V   �� 5    
   -   5        $ 
kalendarTB��5        $��10��6   $��4��6O   $��1��6�   $��10q�6�   �� 5"   
   -   5        $��Generuj rozvrhové akce��5"      $��5��6G   $��0��6T   $��2��6d   $��10q�6x   $��30��6�   �� 5#   
   -   5        $��chyba��5#      $��6��6!   $��0��6.   
���  ��$��10q�6O   $
��Bold"�6[   5$      5%      
   M S B A M L   `   `   `  ����E  ASecureVast, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:SecureVast
SecureVast  5   	       SecureVast.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:SecureVast     5   	   -   5          � WindowStartupLocation$  CenterScreen=�5   	    � 
ResizeMode$ NoResize=�5	   	    � Title$ 
SecureVast��5
   	   $	��360��6   $	��450��6)   .��5      � .+�5   
   �� -   5         ��Name$ 	Uppercase��5      $��	Uppercase��6&   $
��Left=�6:   $��	15,96,0,0q�6U   $	��Top=�6h    d� 	IsChecked$
 TrueY�6�    � ToolTip$  ABCDEFGHIJKLMNOPQRSTUVWXYZ��6�   �� 5   
   -   5        $ 	Lowercase��5      $��	Lowercase��6&   $
��Left=�6:   $��
15,124,0,0q�6U   $	��Top=�6i   $
 TrueY�6�   $  abcdefghijklmnopqrstuvwxyz��6�   �� 5   
   -   5        $ Numbers��5      $��Numbers��6$   $
��Left=�66   $��
15,152,0,0q�6Q   $	��Top=�6e   $
 TrueY�6}   $ 
0123456789��6�   �� 5   
   $��Preferences��6   $
��Left=�6&   $��9,55,0,0q�6A   $	��Top=�6S   $
��Bold"�6k   $��18(�6}   �� 5   
   -   5         ��Name$	 num��5      $
��Left=�6   $��21��6:   $��
172,65,0,0q�6F    �� TextWrapping$
 Wrap=�6Z   $��12��6o   $��1q�6y   $	��Top=�6�    �� TextAlignment$ Center=�6�   $��29��6�   	 �� 	MaxLength$		 100��6�   
 �� MaxLines$
 1��6�   �� 5   
   $��Length��6   $
��Left=�6!   $��
125,61,0,0q�6<   $	��Top=�6P   �� 5   
   -   5        $��Generate��5      $
��Left=�6$   $��
15,283,0,0q�6?   $	��Top=�6S   $	��116��6k   $��0q�6w   $��33��6�   $��20(�6�   $
��Bold"�6�   �� 5   
   -   5        $ Currencysymbols��5      $��Currency symbols��6,   $
��Left=�6G   $��125,180,0,0q�6b   $	��Top=�6w   �� 5   
   -   5        $ Symbols��5      $��Symbols��6$   $
��Left=�66   $��
15,178,0,0q�6Q   $	��Top=�6e   �� 5   
   ���	#FFDDDDDD$
��Left=�6%   $��33��6@   $��143,283,0,0q�6L   ���	#FF707070$	��Top=�6t   ��6�   ��  �� ElementName$ 
resulttext�� �� Path$ ActualWidth��� 5   
   -	   5         ��Name$ 
resulttext��5      $��x��6$   $
��Left=�60   $��143,280,0,0q�6K   $	��Top=�6`   $
��Bold"�6x   $��20(�6�   6  �� 5   
   -
   5        $
��Left=�5      $��84��6+   $��	9,-19,0,0q�67   $	��Top=�6J   $��79��6b   $��Resources/bitmap.png��6m   $) #github.com/AZProductions/securevast��6�   �� 5   
   -   5         ��Name$ copyrectangle��5      ���	#FF0066BB$
��Left=�6<   $��29��6W   $��152,258,0,0q�6c   ���	#00000000$	��Top=�6�   $��77��6�   �� 5   
   -   5        $ 	copylabel��5      $��Click to copy��6#   $
��Left=�6;   $��151,258,0,0q�6V   $	��Top=�6k   $��12(�6�   
�������6�   �� 5   
   -   5        $ LatinExtendedA��5      $��Latin Extended-A��6+   $
��Left=�6F   $��
125,94,0,0q�6a   $	��Top=�6u   �� 5   
   -   5        $ LatinExtendedB��5      $��Latin Extended-B��6+   $
��Left=�6F   $��125,124,0,0q�6a   $	��Top=�6v   �� 5   
   -   5        $ HistoricandPhonetic��5      $��Historic and Phonetic��60   $
��Left=�6P   $��125,152,0,0q�6k   $	��Top=�6�   �� 5   
   -   5        $ RomanNumerals��5      $��Roman Numerals��6*   $
��Left=�6C   $��125,208,0,0q�6^   $	��Top=�6s   �� 5   
   -   5        $ Greek��5      $��Greek��6"   $
��Left=�62   $��
15,206,0,0q�6M   $	��Top=�6a   �� 5    
   -   5        $ Cyrillic��5       $��Cyrillic��6%   $
��Left=�68   $��271,206,0,0q�6S   $	��Top=�6h   �� 5!   
   -   5        $ GreekExtended��5!      $��Greek Extended��6*   $
��Left=�6C   $��
15,234,0,0q�6^   $	��Top=�6r   �� 5"   
   -   5        $ Coptic��5"      $��Coptic��6#   $
��Left=�64   $��271,180,0,0q�6O   $	��Top=�6d   �� 5#   
   -   5        $ EnclosedAlphanumerics��5#      $��Enclosed Alphanumerics��62   $
��Left=�6S   $��
271,94,0,0q�6n   $	��Top=�6�   �� 5$   
   -   5        $ GeometricShapes��5$      $��Geometric Shapes��6,   $
��Left=�6G   $��271,124,0,0q�6b   $	��Top=�6w   �� 5%   
   -   5        $ MathematicalOperators��5%      $��Mathematical Operators��62   $
��Left=�6S   $��271,152,0,0q�6n   $	��Top=�6�   �� 5&   
   -   5        $ CroatianSlovenianRumanian��5&      $#��Croatian, Slovenian, Rumanian��66   $
��Left=�6^   $��125,236,0,0q�6y   $	��Top=�6�   �� 5'   
   $#��Version 1.0, AZ Software 2021��6   $
��Left=�68   $��	88,10,0,0q�6S   $	��Top=�6f   ���	#FF8D8D8D$��10(�6�   �� 5(   
   -   5        $
��Left=�5(      $��44��6+   $��	394,0,0,0q�67   $	��Top=�6J   $��40��6b   $��Resources/100p.png��6m    J� RenderTransformOrigin$ 0.138,0.477&�6�   $ github.com/AZProductions��6�   5)      5*      
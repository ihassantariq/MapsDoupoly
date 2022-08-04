# MapsDoupoly
## How to run the app?

Please use visual studio 2019, if you are deploying to actual IOS application you have to resgister or change info.plist for Bundle ID. Google API key for Android is already there if you want to use your own you can just follow the details described here: https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/map/setup

## Notes on implementations / tradeoffs in building the app

App is using xamarin forms, is using MVVM https://docs.microsoft.com/en-us/xamarin/xamarin-forms/xaml/xaml-basics/data-bindings-to-mvvm pattern instead of working directly over the page backend file. I have used Xamarin.Forms maps instead of using any other SDK, https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/map/. There is also Xamarin.Essential package is being used for geocoding and getting current location to show the pin. Keep in mind there is timer that gets location after every 10 seconds so to see the pin after giving permission you might have to wait a little. 

## Architectural considerations
MVVM and Xamarin.Forms
## Parts you put time/focus in implementing
It takes 10 seconds after giving permission to show the current location and showing the pin. After user move 20 meters and alert is shown that pin location will be changed to users current location. 

## Code you copied or referenced from Stackoverflow, MSDN, other developer blogs, etc

https://github.com/xamarin/xamarin-forms-samples/blob/main/WorkingWithMaps/WorkingWithMaps/WorkingWithMaps/PinPage.xaml
https://docs.microsoft.com/en-us/xamarin/essentials/geocoding?context=xamarin%2Fandroid&tabs=android
https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.Device.StartTimer?view=xamarin-forms
https://docs.microsoft.com/en-us/xamarin/xamarin-forms/xaml/xaml-basics/data-bindings-to-mvvm
https://www.youtube.com/watch?v=rgOwa7TQvIU
https://docs.microsoft.com/en-us/answers/questions/205619/xamarin-forms-how-to-bind-the-position-value-of-xa.html


## Hours spent on app

4-5h to setup and run the app and test it on both android and IOS. 

## Parts of note - something you’re proud to show
Nothing pretty basic everything, I didn't added test cases. Maybe using MVVM instead of backend file. 


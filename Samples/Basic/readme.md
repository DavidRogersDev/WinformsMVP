# Basic Sample

This sample shows the most basic usage of WinformsMVP. It is using convention to bind the Presenters to the Views. To examine this, lets first start with the **MainView** form. This is the form that loads on startup.

## MainView

Note the name of the form: **Main**View  
Note the name of the presenter: **Main**Presenter

They are both prefixed with **Main**. The framework, when binding by convention, will look in the **Presenters** folder and try and find a Presenter with a same prefix as the form. (It works the same with UserControls).

There are a couple of other places that the framework will search for presenters. The actual code looks something like (the 4 options):

    "{namespace}.Logic.Presenters.{presenter}",
    "{namespace}.Presenters.{presenter}",
    "{namespace}.Logic.{presenter}",
    "{namespace}.{presenter}"

So, as an alternative (for example), you may put your Presenters inside a **Logic** folder.

You will also see that `MainView`:

1.  inherits from `MvpForm`, instead of `Form`.
2.  implements `IMainView`, which happens to be the closed generic type of the class which `MainPresenter` inherits from i.e. `Presenter<IMainView>`.

That 2nd point is a really important piece of glue between the Form and the Presenter as it permits you to call members (properties and methods) on the View.

And that completes the circle in terms of how you bind a View to a Presenter _by convention_.

## ChildForm2View

I now want to focus on ChildForm2View. It is a little different from ChildForm1View in the way that it provides access to the Model.

The `ChildForm2View` class inherits from a generic version of **MvpForm** i.e. `MvpForm<PersonViewModel>`.

That version of the **MvpForm** class has a property called Model. This enables you to access that property in your presenter directly.  
For example, in ChildForm2Presenter, you can see me setting the Model directly in the line:  
`View.Model = new PersonViewModel {FirstName = "Lorenzo", LastName = "Lamas"};`

This provides a convenient way for the Presenter to manipulate the Model which backs the View.

**Warning:** there is a drawback to this approach. The Forms designer in Visual Studio does not play well with classes that inherit from a class that include generics. You may well find that you lose the ability to use the designer for any View which inherits from the version of **MvpForm** that has a generic. This is not a bug in Visual Studio (as many claim). It just does not support it. There is a subtle difference (well, a huge one actually).

There is a work-around detailed here in the comment entitled **Vs Designer Can not suport Generic Form** - https://www.codeproject.com/Articles/522809/WinForms-MVP-An-MVP-Framework-for-WinForms?fid=1824550&df=90&mpp=25&sort=Position&spc=Relaxed&tid=4575855 (check out comments by N Meakins and those in that thread)\


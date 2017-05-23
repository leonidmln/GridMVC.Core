Quick start with Grid.Mvc

To start displaying Grid you need to retrieve the collection of Model items in your project, for example:

Your model class:

public class Foo
{
	public string Title {get; set;}
	public string Description {get;set;}
}

Now, imagine that you have a controller action which retrieve a strongly-typed collection of Model property and pass it to the View:

public ActionResult Index()
{
        var items = fooRepository.GetAll();
        return View(items);
}

Now you need to render your items collection in the View. 

To render GridMvc - you can use Html helper extension. 

First, reference GridMvc.Html namespace in the view:

@using GridMvc.Html

Render Grid.Mvc on the page:

@using GridMvc.Html

@Html.Grid(Model).Columns(columns =>
           {
                 columns.Add(foo => foo.Title).Titled("Custom column title").SetWidth(110);
                 columns.Add(foo => foo.Description).Sortable(true);
           }).WithPaging(20)

By default, this html helper method render "_Grid.cshtml" partial view in your Views/Shared folder. If you want to render other view - specify his name in 'viewName' parameter, like this:
<code>
@using GridMvc.Html

@Html.Grid(Model,"_MyCustomGrid").Columns(columns =>
          {
                columns.Add(foo => foo.Title).Titled("Custom column title").SetWidth(110);
                columns.Add(foo => foo.Description).Sortable(true);
          }).WithPaging(20)
</code>	  

For more documentation about column options, please see: Custom columns.

In the last step you need to ensure, that Grid.Mvc stylesheet and scripts registred in your page. Grid.Mvc scripts uses jQuery to provide client side functionality. You need register them too.

In your _Layout.cshtml file:

	<script src="@Url.Content("~/Scripts/jquery.min.js")" type="text/javascript"> </script>
	<link href="@Url.Content("~/Content/Gridmvc.css")" rel="stylesheet" type="text/css" />
	<script src="@Url.Content("~/Scripts/gridmvc.min.js")" type="text/javascript"> </script>


Read more: <a href="#>Paging in Grid.Mvc</a>


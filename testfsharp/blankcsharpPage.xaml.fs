namespace testfsharp

open System
open Xamarin.Forms
open Amazon;
open Amazon.DynamoDBv2
open Amazon.Runtime
open FSharp.AWS.DynamoDB



type Feed =
    {
        [<HashKey>]
        GoalId : string
        EmployeeId : string

        EmployeeName : string
        ManagerId : string
        ManagerName: string
        OneUpManagerId: string
        OneUpManagerName: string


    }

type blankcsharpPage() = 
    inherit ContentPage()
    do 
        let client = new AmazonDynamoDBClient(
                        new SessionAWSCredentials(
                            "ASIAJVBAOFD5LXDBEV6A", 
                            "5i/UX8y775owK0OBcT/yEOqGg1v6qExNo3P2NsWv",
                            "FQoDYXdzEHoaDOJ/ULI2ZlkjWlejWCLHAe9ijXDmYNpXB3bTqPpCPzcyIc9DonBVdoOK5+CSM7InTSotRjsw1iSJatZbihkPoXtk5pJAgpRFcmOYOstMY4uRFnctjf3gAO1cd+EpwKzRiMFkXEC8isSZyrheiNzauDbLPk6TN60bDctiMoqKjIpZj1YKxjBdoCzzqQudXPN0V0O2Qtil7Ufiqcz7xiQ0Mo8x3yBbkTvyt5JBRjCba58TCfmbiun2DCFQRT+6ZKDToxv8OtNOCbCz+nJ/lfNi89IgcYZuz7gopuHTvAU="),
                        RegionEndpoint.APSoutheast2)

        let table = TableContext.Create<Feed>(client, tableName = "PerformanceComments.TOM.Feed", createIfNotExists = true)
            


        let sResults = table.Scan <@ fun r -> r.EmployeeName = "Ceola"  @>

        let items = 
            sResults 
            |> Array.map (fun i ->  new TextCell ( Text = i.EmployeeName, Detail = i.ManagerName))

        let tctype = typedefof<TextCell>

        let template = new DataTemplate(tctype)
        template.SetBinding(TextCell.TextProperty,"Text")
        template.SetBinding(TextCell.DetailProperty,"Detail")

        let listView = ListView();
        listView.ItemsSource <- items
        listView.ItemTemplate <- template

        let layout = StackLayout() 
        layout.Children.Add(listView)
        base.Content <- layout

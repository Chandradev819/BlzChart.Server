window.onload = function () {
    google.charts.load('current', { 'packages': ['geochart', 'corechart', 'columnchart'] });

}

function loadMe(input, input2) {
    google.charts.setOnLoadCallback(drawRegionsBar.bind(null, input, input2));
}

function drawRegionsBar(input, input2) {

    //var data = google.visualization.arrayToDataTable([
    //    ['Genre', 'Fantasy & Sci Fi', 'Romance', 'Mystery/Crime', 'General',
    //        'Western', 'Literature', { role: 'annotation' }],
    //    ['2023', 28, 19, 29, 30, 12, 13, '']
    //]);
    input.push({ role: 'annotation' });
    input2.push('');
    var inp = [input, input2];
    console.log(inp);


    data = google.visualization.arrayToDataTable(inp);
    //var view = new google.visualization.DataView(data);
    //view.setColumns([0, 1,
    //    {
    //        calc: "stringify",
    //        sourceColumn: 1,
    //        type: "string",
    //        role: "annotation"
    //    },
    //    2]);
    var options = {
        title: 'Funded vs Spend',
        width: 350,
        height: 450,
        legend: { position: 'right', maxLines: 3, textStyle: { fontSize: 16 } },
        bar: { groupWidth: '75%' },
        isStacked: true,
        is3D: true
    };
    var chart = new google.visualization.ColumnChart(document.getElementById("chart_div2"));
    chart.draw(data, options);
}


function InitClick(){
  $("#commit").click(function(){
    GetTableData();	
  });
}

function GetTableData(){
  // 通过 $("#")获得到的，是个数组。所以这里取第一个，自信id不会重
  var table=$("#myTable")[0];
  var rows=table.rows;

  var data = {
    "items":[]
  }
  for (var i = 0; i < rows.length; i++) {
    data.items.push(Row2Item(rows[i]));
  }
}
function Row2Item(row){
  var item = {
    "key":row.cells[0].innerText,
    "content":row.cells[1].innerText,
    "isNecessary":row.cells[2].innerText,
    "introduce":row.cells[3].innerText
  }
  return item;
}
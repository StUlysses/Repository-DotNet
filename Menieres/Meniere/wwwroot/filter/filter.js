//SQL及脏话过滤 待完成
//con 需过滤的内容  标签id
function SQLFilter(con,id) {

}
//弹出气泡
//id:标签id ， con:要弹出的内容
function tooltipTool(id,con) {
    $('#' + id).attr('data-original-title', con);
    $('#' + id).tooltip('show');
    setTimeout(function () { $('#RegisterPassword').tooltip('dispose') }, 2000);
    return false;
}
//正文的换行符替换
function ContentFilter(con) {
    var res = con.replace(/(\r\n)|(\n)/g, 'nnnrrr');
    return res;
}

function ContentReplace(con) {
    var res = con.replace(/nnnrrr/g, '<br/>');
    return res;
}

//点击导航按钮
function ClickLink(obj) {
    $('.nav-link').each(function () {
        $(this).removeClass('active');
    });
    $(obj).addClass('active');
    //console.log(obj.text)
    switch (obj.text) {
        case '登录':
            $('#LoginDiv').css('display', '');
            $('#RegisterDiv').css('display', 'none');
            $('#EditDiv').css('display', 'none');
            break;
        case '注册':
            $('#LoginDiv').css('display', 'none');
            $('#RegisterDiv').css('display', '');
            $('#EditDiv').css('display', 'none');
            break;
        case '修改密码':
            $('#LoginDiv').css('display', 'none');
            $('#RegisterDiv').css('display', 'none');
            $('#EditDiv').css('display', '');
            break;
    }
}
//注册
function RegisterUser() {
    var name = $('#RegisterUserName').val();
    if (name == '') {
        $('#RegisterUserName').attr('data-original-title', '用户名不能为空');
        $('#RegisterUserName').tooltip('show');
        setTimeout(function () { $('#RegisterUserName').tooltip('dispose') }, 2000);
        return false;
    }
    var word = $('#RegisterPassword').val();
    if (word == '') {
        $('#RegisterPassword').attr('data-original-title', '密码不能为空');
        $('#RegisterPassword').tooltip('show');
        setTimeout(function () { $('#RegisterPassword').tooltip('dispose') }, 2000);
        return false;
    }
    $.ajax({
        url: '/User/Register',
        type: 'POST',
        data: {
            'UserName': name,
            'Password': word
        },
        async: 'false',
        success: function (data) {
            if (data.code == 200) {
                window.location.href = '/Poem/Index?msg='+data.msg;
            } else {
                PopDialog('注册失败', data.msg);
            }
        }
    });
}
//登录
function LoginAction() {
    var name = $('#LoginUserName').val();
    if (name == '') {
        $('#LoginUserName').attr('data-original-title', '用户名不能为空');
        $('#LoginUserName').tooltip('show');
        setTimeout(function(){ $('#LoginUserName').tooltip('dispose') }, 2000);
        return false;
    }
    var word = $('#LoginPassword').val();
    if (word == '') {
        $('#LoginPassword').attr('data-original-title', '密码不能为空');
        $('#LoginPassword').tooltip('show');
        setTimeout(function () { $('#LoginPassword').tooltip('dispose') }, 2000);
        return false;
    }
    $.ajax({
        url: '/User/Login',
        type: 'POST',
        data: {
            'UserName': name,
            'Password': word
        },
        async: 'false',
        success: function (data) {
            if (data.code == 200) {
                window.location.href = '/Poem/Index?msg='+data.msg;
            } else {
                PopDialog('登录失败', data.msg);
            }
        }
    });
}
//修改密码
function EditUserInfo() {
    var name = $('#InfoUserName').val();
    if (name == '') {
        $('#InfoUserName').attr('data-original-title', '用户名不能为空');
        $('#InfoUserName').tooltip('show');
        setTimeout($('#InfoUserName').tooltip('hide'), 2000);
        return false;
    }
    var word = $('#InfoPassword').val();
    var word2 = $('#InfoRePassword').val();
    if (word == '') {
        $('#InfoRePassword').attr('data-original-title', '密码不能为空');
        $('#InfoRePassword').tooltip('show');
        setTimeout(function () { $('#InfoRePassword').tooltip('dispose') }, 2000);
        return false;
    }
    if (word != word2) {
        $('#InfoRePassword').attr('data-original-title', '两次密码必须一致');
        $('#InfoRePassword').tooltip('show');
        setTimeout(function () { $('#InfoRePassword').tooltip('dispose') }, 2000);
        return false;
    }
    $.ajax({
        url: '/User/EditUser',
        type: 'POST',
        data: {
            'UserName': name,
            'Password': word
        },
        async: 'false',
        success: function (data) {
            if (data.code == 200) {
                window.location.href = '/Poem/Index?msg=' + data.msg;
            } else {
                PopDialog('保存失败', data.msg);
            }
        }
    });
}
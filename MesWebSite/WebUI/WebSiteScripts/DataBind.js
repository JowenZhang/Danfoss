//绑定权限组
function bindAuthGroup() {
    $('#CmbAuthGroup').combobox({
        url: '/BackgroundProgram/bindData.ashx?',
        queryParams: { fields: "auth_group_no,auth_group_name", table: "sys_auth_group", where: strBase64("status_no='310'") },
        valueField: 'auth_group_no',
        textField: 'auth_group_name',
        required: true,
        editable: false,
        onLoadSuccess: function () {  //加载完成后,设置选中第一项
            var val = $('#CmbAuthGroup').combobox("getData");
            if (val.length > 0) {
                //设置第一个值为选中值
                $('#CmbAuthGroup').combobox('select', val[0].auth_group_no);
            }
            else {
                var data = [];
                data.push({ auth_group_no: 'default', auth_group_name: 'default', selected: 'true' });
                $('#CmbAuthGroup').combobox("select", data);
            }
        }
    });
}

//绑定菜单
function bindMenu() {
    $('#CmbMenu').combobox({
        url: '/BackgroundProgram/bindData.ashx',
        queryParams:{fields:"menu_no,menu_name",table:"sys_menu",where:strBase64("status_no='310'")},
        valueField: 'menu_no',
        textField: 'menu_name',
        required: true,
        editable: false,
        onLoadSuccess: function () {  //加载完成后,设置选中第一项
            var val = $('#CmbMenu').combobox("getData");
            if (val.length > 0) {
                //设置第一个值为选中值
                $('#CmbMenu').combobox('select', val[0].menu_no);
            }
            else {
                var data = [];
                data.push({ menu_no: 'default', menu_name: 'default', selected: 'true' });
                $('#CmbMenu').combobox('select', data);
            }
        }
    });
}

//绑定审核类型
function bindApo() {
    $('#CmbApo').combobox({
        url: '/BackgroundProgram/bindData.ashx',
        queryParams: { fields: "apo_no,apo_name", table: "apo", where: strBase64("status_no='310'") },
        valueField: 'apo_no',
        textField: 'apo_name',
        required: true,
        editable: false,
        onLoadSuccess: function () {  //加载完成后,设置选中第一项
            var val = $('#CmbApo').combobox("getData");
            if (val.length > 0) {
                //设置第一个值为选中值
                $('#CmbApo').combobox('select', val[0].apo_no);
            }
            else {
                var data = [];
                data.push({ apo_no: 'default', apo_name: 'default', selected: 'true' });
                $('#CmbApo').combobox('select', data);
            }
        }
    });
}

//绑定用户
function bindUser() {
    $('#CmbUser').combobox({
        url: '/BackgroundProgram/bindData.ashx',
        queryParams: { fields: "user_no,user_name", table: "sys_user", where: strBase64("status_no='310'") },
        valueField: 'user_no',
        textField: 'user_name',
        required: true,
        editable: false,
        onLoadSuccess: function () {  //加载完成后,设置选中第一项
            var val = $('#CmbUser').combobox("getData");
            if (val.length > 0) {
                //设置第一个值为选中值
                $('#CmbUser').combobox('select', val[0].user_no);
            }
            else {
                var data = [];
                data.push({ 'user_no': 'default', 'user_name': 'default', 'selected': 'true' });
                $('#CmbUser').combobox('select', data);
            }
        }
    });
}

//绑定下侧状态--300系列
function bindStatusBottom3() {
    var data = [];
    data.push({ status_no: '310', status_name: '已确认', selected: 'true' }, { status_no: '300', status_name: '未确认' });
    $('#CmbStatusBottom').combobox('loadData', data);
}

//绑定上侧状态--300系列
function bindStatusTop3() {
    var data = [];
    data.push({ status_no: '310', status_name: '已确认', selected: 'true' }, { status_no: '300', status_name: '未确认' });
    $('#CmbStatusTop').combobox('loadData', data);
}

//绑定下侧状态--500系列
function bindStatusBottom5() {
    var data = [];
    data.push({ status_no: '510', status_name: '已处理', selected: 'true' }, { status_no: '500', status_name: '待处理' }, { status_no: '520', status_name: '进行中' });
    $('#CmbStatusBottom').combobox('loadData', data);
}

//绑定上侧状态--500系列
function bindStatusTop5() {
    var data = [];
    data.push({ status_no: '510', status_name: '已处理', selected: 'true' }, { status_no: '500', status_name: '待处理' }, { status_no: '520', status_name: '进行中' });
    $('#CmbStatusTop').combobox('loadData', data);
}

//绑定上侧订单下发状态--400系列
function bindCommitStatusTop4() {
    var data = [];
    data.push({ status_no: '410', status_name: '已下发', selected: 'true' }, { status_no: '400', status_name: '未下发' });
    $('#CmbCommitStatusTop').combobox('loadData', data);
}

//绑定上侧订单完工状态--200系列
function bindProcedureStatusTop2() {
    var data = [];
    data.push({ status_no: '210', status_name: '已完工', selected: 'true' }, { status_no: '200', status_name: '生产中' },{ status_no: '220', status_name: '未开工' });
    $('#CmbProcedureStatusTop').combobox('loadData', data);
}

//绑定用户性别
function bindUserGender() {
    var data = [];
    data.push({ gender_no: '未知', gender_name: '未知', selected: 'true' }, { gender_no: '男', gender_name: '男' }, { gender_no: '女', gender_name: '女' });
    $('#CmbUserGender').combobox('loadData', data);
}

//绑定能否登陆
function bindLoginable() {
    data = [];
    data.push({ bool_value: '1', bool_mask: '是', selected: 'true' }, { bool_value: '0', bool_mask: '否' });
    $('#CmbLoginable').combobox('loadData', data);
}

//绑定能否修改密码
function bindPwdChangeable() {
    data = [];
    data.push({ bool_value: '1', bool_mask: '是', selected: 'true' }, { bool_value: '0', bool_mask: '否' });
    $('#CmbPwdChangeable').combobox('loadData', data);
}

//绑定用户是否同时为作业员
function bindIsWorker()
{
    data = [];
    data.push({ bool_value: '1', bool_mask: '是', selected: 'true' }, { bool_value: '0', bool_mask: '否' });
    $('#CmbIsWorker').combobox('loadData', data);
}

//绑定集团
function bindGroup() {
    $('#CmbGroup').combobox({
        url: '/BackgroundProgram/bindData.ashx',
        queryParams: { fields: "group_no,group_name", table: "sys_group", where: strBase64("status_no='310'") },
        valueField: 'group_no',
        textField: 'group_name',
        required: true,
        editable: false,
        onLoadSuccess: function () {  //加载完成后,设置选中第一项
            var val = $('#CmbGroup').combobox("getData");
            if (val.length > 0) {
                //设置第一个值为选中值
                $('#CmbGroup').combobox('select', val[0].group_no);
            }
            else {
                var data = [];
                data.push({ group_no: 'default', group_name: 'default', selected: 'true' });
                $('#CmbGroup').combobox('loadData', data);               
            }
        }
    });
}


//绑定公司
function bindCompany() {
    $('#CmbCompany').combobox({
        url: '/BackgroundProgram/bindData.ashx',
        queryParams: { fields: "company_no,company_name", table: "sys_company", where: strBase64("status_no='310'") },
        valueField: 'company_no',
        textField: 'company_name',
        required: true,
        editable: false,
        onLoadSuccess: function () {  //加载完成后,设置选中第一项
            var val = $('#CmbCompany').combobox("getData");
            if (val.length > 0) {
                //设置第一个值为选中值
                $('#CmbCompany').combobox('select', val[0].company_no);
            }
            else {
                var data = [];
                data.push({ company_no: 'default', company_name: 'default', selected: 'true' });
                $('#CmbCompany').combobox('loadData', data);               
            }
        }
    });
}

//绑定部门
function bindDept() {
    $('#CmbDept').combobox({
        url: '/BackgroundProgram/bindData.ashx',
        queryParams: { fields: "dept_no,dept_name", table: "sys_dept", where: strBase64("status_no='310'") },
        valueField: 'dept_no',
        textField: 'dept_name',
        required: true,
        editable: false,
        onLoadSuccess: function () {  //加载完成后,设置选中第一项
            var val = $('#CmbDept').combobox("getData");
            if (val.length > 0) {
                //设置第一个值为选中值
                $('#CmbDept').combobox('select', val[0].dept_no);
            }
            else {
                var data = [];
                data.push({ dept_no: 'default', dept_name: 'default', selected: 'true' });
                $('#CmbDept').combobox('select', data);
            }
        }
    });
}

//绑定工厂
function bindFactory() {
    $('#CmbFactory').combobox({
        url: '/BackgroundProgram/bindData.ashx',
        queryParams: { fields: "factory_no,factory_name", table: "sys_factory", where: strBase64("status_no='310'") },
        valueField: 'factory_no',
        textField: 'factory_name',
        required: true,
        editable: false,
        onLoadSuccess: function () {  //加载完成后,设置选中第一项
            var val = $('#CmbFactory').combobox("getData");
            if (val.length > 0) {
                //设置第一个值为选中值
                $('#CmbFactory').combobox('select', val[0].factory_no);
            }
            else {
                var data = [];
                data.push({ factory_no: 'default', factory_name: 'default', selected: 'true' });
                $('#CmbFactory').combobox('select', data);
            }
        }
    });
}

//绑定车间
function bindWorkshop() {
    $('#CmbWorkshop').combobox({
        url: '/BackgroundProgram/bindData.ashx',
        queryParams: { fields: "workshop_no,workshop_name", table: "pdm_workshop", where: strBase64("status_no='310'") },
        valueField: 'workshop_no',
        textField: 'workshop_name',
        required: true,
        editable: false,
        onLoadSuccess: function () {  //加载完成后,设置选中第一项
            var val = $('#CmbWorkshop').combobox("getData");
            if (val.length > 0) {
                //设置第一个值为选中值
                $('#CmbWorkshop').combobox('select', val[0].workshop_no);
            }
            else {
                var data = [];
                data.push({ workshop_no: 'default', workshop_name: 'default', selected: 'true' });
                $('#CmbWorkshop').combobox('select', data);
            }
        }
    });
}

//绑定产线
function bindLine() {
    $('#CmbLine').combobox({
        url: '/BackgroundProgram/bindData.ashx',
        queryParams: { fields: "line_no,line_name", table: "pdm_line", where: strBase64("status_no='310'") },
        valueField: 'line_no',
        textField: 'line_name',
        required: true,
        editable: false,
        onLoadSuccess: function () {  //加载完成后,设置选中第一项
            var val = $('#CmbLine').combobox("getData");
            if (val.length > 0) {
                //设置第一个值为选中值
                $('#CmbLine').combobox('select', val[0].line_no);
            }
            else {
                var data = [];
                data.push({ line_no: 'default', line_name: 'default', selected: 'true' });
                $('#CmbLine').combobox('select', data);
            }
        }
    });
}

//绑定班次
function bindShift() {
    $('#CmbShift').combobox({
        url: '/BackgroundProgram/bindData.ashx',
        queryParams: { fields: "shift_no,shift_name", table: "pdm_shift", where: strBase64("status_no='310'") },
        valueField: 'shift_no',
        textField: 'shift_name',
        required: true,
        editable: false,
        onLoadSuccess: function () {  //加载完成后,设置选中第一项
            var val = $('#CmbShift').combobox("getData");
            if (val.length > 0) {
                //设置第一个值为选中值
                $('#CmbShift').combobox('select', val[0].shift_no);
            }
            else {
                var data = [];
                data.push({ shift_no: 'default', shift_name: 'default', selected: 'true' });
                $('#CmbShift').combobox('select', data);
            }
        }
    });
}


//绑定设备
function bindEqm() {
    $('#CmbEqm').combobox({
        url: '/BackgroundProgram/bindData.ashx',
        queryParams: { fields: "eqm_no,eqm_name", table: "pdm_eqm", where: strBase64("status_no='310' order by eqm_no") },
        valueField: 'eqm_no',
        textField: 'eqm_name',
        required: true,
        editable: false,
        onLoadSuccess: function () {  //加载完成后,设置选中第一项
            var val = $('#CmbEqm').combobox("getData");
            if (val.length > 0) {
                //设置第一个值为选中值
                $('#CmbEqm').combobox('select', val[0].eqm_no);
            }
            else {
                var data = [];
                data.push({ eqm_no: 'default', eqm_name: 'default', selected: 'true' });
                $('#CmbEqm').combobox('select', data);
            }
        }
    });
}

//绑定设备
function bindEqmToolBar() {
    $('#TopToolCmbEqm').combobox({
        url: '/BackgroundProgram/bindData.ashx',
        queryParams: { fields: "eqm_no,eqm_name", table: "pdm_eqm", where: strBase64("status_no='310' order by eqm_no desc") },
        valueField: 'eqm_no',
        textField: 'eqm_name',
        required: true,
        editable: false,
        onLoadSuccess: function () {  //加载完成后,设置选中第一项
            var val = $('#TopToolCmbEqm').combobox("getData");
            if (val.length > 0) {
                //设置第一个值为选中值
                $('#TopToolCmbEqm').combobox('select', val[0].eqm_no);
            }
            else {
                var data = [];
                data.push({ eqm_no: 'default', eqm_name: 'default', selected: 'true' });
                $('#TopToolCmbEqm').combobox('select', data);
            }
        }
    });
}

//绑定停机原因
function bindEqmJamCause() {
    $('#CmbEqmJamCause').combobox({
        url: '/BackgroundProgram/bindData.ashx',
        queryParams: { fields: "jam_cause_no,jam_cause_name", table: "eqm_jam_cause", where: strBase64("status_no='310'") },
        valueField: 'jam_cause_no',
        textField: 'jam_cause_name',
        required: true,
        editable: false,
        onLoadSuccess: function () {  //加载完成后,设置选中第一项
            var val = $('#CmbEqmJamCause').combobox("getData");
            if (val.length > 0) {
                //设置第一个值为选中值
                $('#CmbEqmJamCause').combobox('select', val[0].jam_cause_no);
            }
            else {
                var data = [];
                data.push({ jam_cause_no: 'default', jam_cause_name: 'default', selected: 'true' });
                $('#CmbEqmJamCause').combobox('select', data);
            }
        }
    });
}

//绑定质量异常代码
function bindQaCause() {
    $('#CmbQaCause').combobox({
        url: '/BackgroundProgram/bindData.ashx',
        queryParams: { fields: "qa_cause_no,qa_cause_name", table: "qcm_qa_cause", where: strBase64("status_no='310'") },
        valueField: 'qa_cause_no',
        textField: 'qa_cause_name',
        required: true,
        editable: false,
        onLoadSuccess: function () {  //加载完成后,设置选中第一项
            var val = $('#CmbQaCause').combobox("getData");
            if (val.length > 0) {
                //设置第一个值为选中值
                $('#CmbQaCause').combobox('select', val[0].qa_cause_no);
            }
            else {
                var data = [];
                data.push({ qa_cause_no: 'default', qa_cause_name: 'default', selected: 'true' });
                $('#CmbQaCause').combobox('select', data);
            }
        }
    });
}

//绑定质检结果
function bindQaResult() {
    $('#CmbQaResult').combobox({
        url: '/BackgroundProgram/bindData.ashx',
        queryParams: { fields: "result_no,result_name", table: "qcm_qa_result", where: strBase64("status_no='310'") },
        valueField: 'result_no',
        textField: 'result_name',
        required: true,
        editable: false,
        onLoadSuccess: function () {  //加载完成后,设置选中第一项
            var val = $('#CmbQaResult').combobox("getData");
            if (val.length > 0) {
                //设置第一个值为选中值
                $('#CmbQaResult').combobox('select', val[0].result_no);
            }
            else {
                var data = [];
                data.push({ result_no: 'default', result_name: 'default', selected: 'true' });
                $('#CmbQaResult').combobox('select', data);
            }
        }
    });
}


//绑定质检结果
function bindAndonType() {
    $('#CmbAndonType').combobox({
        url: '/BackgroundProgram/bindData.ashx',
        queryParams: { fields: "andon_type_no,andon_type_name", table: "adn_type", where: strBase64("") },
        valueField: 'andon_type_no',
        textField: 'andon_type_name',
        required: true,
        editable: false,
        onLoadSuccess: function () {  //加载完成后,设置选中第一项
            var val = $('#CmbAndonType').combobox("getData");
            if (val.length > 0) {
                //设置第一个值为选中值
                $('#CmbAndonType').combobox('select', val[0].andon_type_no);
            }
            else {
                var data = [];
                data.push({ andon_type_no: 'default', andon_type_name: 'default', selected: 'true' });
                $('#CmbAndonType').combobox('select', data);
            }
        }
    });
}


//绑定文件类型
function bindFileType() {
    $('#CmbFileType').combobox({
        url: '/BackgroundProgram/bindData.ashx',
        queryParams: { fields: "file_type_no,file_type_name", table: "dms_file_type", where: strBase64("1=1") },
        valueField: 'file_type_no',
        textField: 'file_type_name',
        required: true,
        editable: false,
        onLoadSuccess: function () {  //加载完成后,设置选中第一项
            var val = $('#CmbFileType').combobox("getData");
            if (val.length > 0) {
                //设置第一个值为选中值
                $('#CmbFileType').combobox('select', val[0].file_type_no);
            }
            else {
                var data = [];
                data.push({ file_type_no: 'default', file_type_name: 'default', selected: 'true' });
                $('#CmbFileType').combobox('loadData', data);
            }
        }
    });
}
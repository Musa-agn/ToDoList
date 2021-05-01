Vue.filter('formatDate', function (value) {
    if (value) {
        return moment(String(value)).format('DD/MM/YYYY hh:mm')
    }
});

var todo = new Vue({
    el: "#todo",
    data() {
        return {
            toDoInput: {
                name: '',
                description: '',
                timeToDo: null
            },
            getToDoListInfoData: [],
            updateToDoEnable: false,
            updateToDoInput: {
                id: '',
                name: '',
                description: '',
                timeToDo: null
            },
            getToDoId: "",
            isTimeToDo: false,
            timeToDoData: [],
            todayDate: null,
            errorMessage:''
        }
    },
    created() {
    },
    mounted() {
        this.getToDoList();
    },

    methods: {
        addToDo() {
            this.errorMessage = '';
            axios({
                url: "/ToDo/AddToDo",
                method: "POST",
                data: {
                    addToDoRequest: this.toDoInput
                }
            }).then(resp => {
                this.errorMessage = resp.data.ErrorMessage;
                this.getToDoList();
            }).catch((err) => {
            }).then(() => {
                this.toDoInput = {
                    name: '',
                    description: '',
                    timeToDo: null
                };
                this.updateToDoEnable = false;
                this.updateToDoInput = {};
                this.getToDoId = "";

            });
        },
        update(row) {
            this.updateToDoEnable = true;
            this.updateToDoInput = {
                id: row.Id,
                name: row.Name,
                description: row.Description,
                timeToDo: row.TimeToDo
            }
        },
        updateToDo() {
            this.errorMessage = '';
            axios({
                url: "/ToDo/UpdateToDo",
                method: "POST",
                data: {
                    updateToDoRequest: this.updateToDoInput
                }
            }).then(resp => {
                this.timeToDoData = [];
                this.errorMessage = resp.data.ErrorMessage;
                this.getToDoList();
            }).catch((err) => {
            }).then(() => {
                this.updateToDoEnable = false;
                this.updateToDoInput = {};
                this.getToDoId = "";

            });
        },
        deleteToDo(row) {
            this.errorMessage = '';
            axios({
                url: "/ToDo/DeleteToDo",
                method: "POST",
                data: {
                    deleteToDoRequest: row
                }
            }).then(resp => {
                this.timeToDoData = [];
                this.errorMessage = resp.data.ErrorMessage;
                this.getToDoList();
            }).catch((err) => {
            }).then(() => {
                this.updateToDoEnable = false;
                this.updateToDoInput = {};
                this.getToDoId = "";

            });
        },
        getToDo() {
            this.errorMessage = '';
            axios({
                url: "/ToDo/GetToDo",
                method: "GET",
                params: {
                    id: this.getToDoId
                }
            }).then(resp => {
                this.getToDoListInfoData = []
                this.getToDoListInfoData.push(resp.data);
                this.errorMessage = resp.data.ErrorMessage;
                this.timeToDoData = [];
                this.timeToDoControl();

            }).catch((err) => {
            }).then(() => {
                this.getToDoId = "";
            });
        },
        getToDoList() {
            axios({
                url: "/ToDo/GetToDoList",
                method: "GET"
            }).then(resp => {
                this.getToDoListInfoData = resp.data;
                this.timeToDoData = [];
                this.timeToDoControl();
            }).catch((err) => {
            }).then(() => {
                this.getToDoId = "";
            });
        },

        timeToDoControl() {
            for (var i = 0; i < this.getToDoListInfoData.length; i++) {
                var item = this.getToDoListInfoData[i];
                this.compareDate(item);
            }
            if (this.timeToDoData.length > 0) {
                this.openModal();
            }
        },
        compareDate(item) {
            const today = new Date();
            const todayDate = today.getFullYear() + '-' + (today.getMonth() + 1) + '-' + today.getDate();
            const strTodayDate = this.dateFormat(todayDate);
            if (this.dateFormat(item.TimeToDo) == strTodayDate) {
                var value = this.timeToDoData.filter(function (x) { return x.Id == item.Id });
                if (value.length == 0) {
                    this.timeToDoData.push(item);
                }
            }
        },
        openModal() {
            $(document).ready(function () {
                $("#btnModal").trigger("click");
            });
        },
        dateFormat: function (date) {
            return moment(String(date)).format('YYYY/MM/DD');
        },
    }

})
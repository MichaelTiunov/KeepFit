var Todo = Backbone.Model.extend({
    defaults: {
        title: '',
        checked: false
    }
});

var TodoView = Backbone.View.extend({
    tagName: 'li',
    todoTpl: _.template($('#item-template').html()),
    events: {
        'dbclick label': 'edit',
        'keypress .edit': 'updateOnEnter',
        'blur .edit': 'close'
    },
    initialize: function () {
        this.$el = $('#todo');
    },
    render: function () {
        this.$el.html(this.todoTpl(this.model.toJSON()));
        this.input = this.$('.edit');
        return this;
    },
    edit: function () {

    },
    close: function () {

    },
    updateOnEnter: function () {

    }
});

var myTodo = new Todo({
    title: 'Check attribute'
});

var todoView = new TodoView({ model: myTodo });
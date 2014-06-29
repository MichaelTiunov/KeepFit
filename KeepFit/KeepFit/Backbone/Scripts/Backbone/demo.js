var Todo = Backbone.Model.extend({
    defaults: {
        title: '',
        completed: false
    }
});
var TodosCollection = Backbone.Collection.extend({
    model: Todo
});
var myTodo = new Todo({ title: 'Bla', id: 2 });
var b = new Todo({ title: 'sdf', id: 2 });
var c = new Todo({ title: 'sdfsdf', id: 3 });
var todos = new TodosCollection([myTodo, b]);
todos.add(c);
console.log(todos.length);
todos.remove([myTodo, b, c]);
console.log(todos.length);
var tasksManager = function() {

    // appends a row to the tasks table.
    // @parentSelector: selector to append a row to.
    // @obj: task object to append.
    var appendRow = function(parentSelector, obj) {
        var div = $("<div class='element' data-id='" + obj.ToDoId + "'></div>");
        div.append("<input type='checkbox' class='completed' " + (obj.IsCompleted ? "checked" : "") + "/>");

        div.append("<p class='name' >" + obj.Name + "</p>");
        div.append("<div class='delete-button'></div>");
        $(parentSelector).append(div);
    }

    // adds all tasks as rows (deletes all rows before).
    // @parentSelector: selector to append a row to.
    // @tasks: array of tasks to append.
    var displayTasks = function(parentSelector, tasks) {
        $(parentSelector).empty();
        $.each(tasks, function(i, item) {
            appendRow(parentSelector, item);
        });
    };

    // starts loading tasks from server.
    // @returns a promise.
    var loadTasks = function() {
        return $.getJSON("/api/todos");
    };

    // starts creating a task on the server.
    // @isCompleted: indicates if new task should be completed.
    // @name: name of new task.
    // @return a promise.
    var createTask = function(isCompleted, name) {
        return $.post("/api/todos",
        {
            IsCompleted: isCompleted,
            Name: name
        });
    };

    // starts updating a task on the server.
    // @id: id of the task to update.
    // @isCompleted: indicates if the task should be completed.
    // @name: name of the task.
    // @return a promise.
    var updateTask = function(id, isCompleted, name) {
        return $.ajax(
        {
            url: "/api/todos",
            type: "PUT",
            contentType: 'application/json',
            data: JSON.stringify({
                ToDoId: id,
                IsCompleted: isCompleted,
                Name: name
            })
        });
    };

    // starts deleting a task on the server.
    // @taskId: id of the task to delete.
    // @return a promise.
    var deleteTask = function (taskId) {
        return $.ajax({
            url: "/api/todos/" + taskId,
            type: 'DELETE'
        });
    };

    // returns public interface of task manager.
    return {
        loadTasks: loadTasks,
        displayTasks: displayTasks,
        createTask: createTask,
        deleteTask: deleteTask,
        updateTask: updateTask
    };
}();


$(function () {
    // add new task button click handler
    $("#newCreate").click(function() {
        var isCompleted = $('#newCompleted')[0].checked;
        var name = $('#newName')[0].value;

        tasksManager.createTask(isCompleted, name)
            .then(tasksManager.loadTasks)
            .done(function(tasks) {
                tasksManager.displayTasks("#tasks > .body", tasks);
            });
    });

    // bind update task checkbox click handler
    $("#tasks > .body").on('change', '.completed', function () {
        var div = $(this).parent();
        var taskId = div.attr("data-id");
        var isCompleted = div.find('.completed')[0].checked;
        var name = div.find('.name').text();
        
        tasksManager.updateTask(taskId, isCompleted, name)
            .then(tasksManager.loadTasks)
            .done(function (tasks) {
                tasksManager.displayTasks("#tasks > .body", tasks);
            });
    });

    // bind delete button click for future rows
    $('#tasks > .body').on('click', '.delete-button', function() {
        var taskId = $(this).parent().attr("data-id");
        tasksManager.deleteTask(taskId)
            .then(tasksManager.loadTasks)
            .done(function(tasks) {
                tasksManager.displayTasks("#tasks > .body", tasks);
            });
    });

    $(".body").addClass("loading");
    // load all tasks on startup
    tasksManager.loadTasks()
        .done(function(tasks) {
            tasksManager.displayTasks("#tasks > .body", tasks);
            $(".body").removeClass("loading");
        });
});
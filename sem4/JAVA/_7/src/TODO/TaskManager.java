package TODO;

public class TaskManager {
    private TaskList taskList;

    public TaskManager() {
        this.taskList = new TaskList();
    }

    public void addTask(Task task) {
        taskList.addTask(task);
    }

    public void removeTask(Task task) {
        taskList.removeTask(task);
    }

    public void markTaskAsCompleted(Task task) {
        task.markAsCompleted();
    }

    public TaskList getAllTasks() {
        return taskList;
    }

    public int taskCount(){
        return taskList.getTasks().size();
    }
}



import TODO.Task;
import TODO.TaskManager;

import java.util.List;

public class Main {
    public static void main(String[] args) {
        TaskManager taskManager = new TaskManager();

        // Добавление задач
        taskManager.addTask(new Task("Покормить кота"));
        taskManager.addTask(new Task("Сделать уроки"));
        taskManager.addTask(new Task("Позвонить другу"));

        // Получение списка задач
        List<Task> tasks = taskManager.getAllTasks().getTasks();

        // Вывод списка задач
        for (Task task : tasks) {
            System.out.println(task.getDescription());
        }

        // Отметка задачи как выполненной
        taskManager.markTaskAsCompleted(tasks.get(0));

        // Удаление задачи
        taskManager.removeTask(tasks.get(1));

        // Вывод обновленного списка задач
        tasks = taskManager.getAllTasks().getTasks();
        System.out.println("\nОбновленный список задач:");
        for (Task task : tasks) {
            System.out.println(task.getDescription() + " (Завершено: " + task.isCompleted() + ")");
        }
    }
}

package Tests;

import TODO.Task;
import TODO.TaskManager;

import org.testng.Assert;
import org.testng.annotations.*;

import java.util.List;

public class TaskManagerTests {
    private TaskManager _taskManager;

    @BeforeSuite
    private void createTaskManager(){
        this._taskManager = new TaskManager();
    }

    @BeforeMethod
    private void preparingTest(){
        System.out.println("Running another test!");
    }

    @AfterMethod
    private void finishingTest(){
        System.out.println("Test finished successfully!\n");
    }

    @BeforeTest
    private void statusNotifier(){
        System.out.println("Preparing test (t_addTask)");
    }

    @Test(groups = "main", description = "Test interaction between Task and TaskManager: Adding task")
    public void t_addTask(){
        int prevCount = _taskManager.taskCount();
        _taskManager.addTask(new Task("Test_task"));
        int currentCount = _taskManager.taskCount();

        Assert.assertEquals(currentCount, prevCount+1, "Successfully added task!");
    }

    @Test(groups = "main", description = "Test interaction between TaskList and TaskManager: Removing task")
    public void t_removeTask(){
        int prevCount = _taskManager.taskCount();
        Task task = new Task("Test_task");
        _taskManager.addTask(task);
        _taskManager.removeTask(task);
        int currentCount = _taskManager.taskCount();

        Assert.assertEquals(currentCount, prevCount, "Successfully removed task!");
    }

    @Test(groups = "main", description = "Test interaction between Task and TaskManager: Marking task as completed", timeOut = 10)
    public void t_remarkTask(){
        Task task = new Task("Test_task");
        _taskManager.addTask(task);
        task.markAsCompleted();

        Assert.assertEquals(task.isCompleted(), true, "Successfully finished task!");
    }

    @Test()
    public void t_empty(){
        Assert.assertEquals(true, true, "Empty test completed!");
    }


    @DataProvider(name = "taskData")
    public Object[][] taskData() {
        return new Object[][] {
                { "Task1", true },
                { "Task2", false },
                { "Task3", true }
        };
    }

    @Test(dataProvider = "taskData", description = "Test interaction between Task and TaskManager with external data")
    public void testTaskManager_ExternalData(String description, boolean completed){
        Task task = new Task(description);
        _taskManager.addTask(task);

        List<Task> tasks = _taskManager.getAllTasks().getTasks();
        Task addedTask = tasks.get(tasks.size() - 1);

        Assert.assertEquals(addedTask.getDescription(), description, "Task description matches");
        Assert.assertEquals(addedTask.isCompleted(), completed, "Task completion status matches");
    }

}

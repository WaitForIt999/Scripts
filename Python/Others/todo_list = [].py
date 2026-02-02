todo_list = []

while True:
    print("\nTo-Do List:")
    for i, task in enumerate(todo_list, start=1):
        print(f"{i}. {task}")

    print("\nOptions:")
    print("1. Add task")
    print("2. Remove task")
    print("3. Exit")

    choice = input("Choose an option (1/2/3): ")

    if choice == "1":
        task = input("Enter a new task: ")
        todo_list.append(task)
        print("Task added!")
    
    elif choice == "2":
        try:
            task_num = int(input("Enter the task number to remove: "))
            removed = todo_list.pop(task_num - 1)
            print(f"Removed: {removed}")
        except (ValueError, IndexError):
            print("Invalid task number.")
    
    elif choice == "3":
        print("Goodbye!")
        break
    
    else:
        print("Invalid choice. Please try again.")

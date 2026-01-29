import { Routes } from '@angular/router';
import { Dashboard } from './components/dashboard/dashboard';
import { UsersInfo } from './components/dashboard/users-info/users-info';
import { TasksInfo } from './components/dashboard/tasks-info/tasks-info';
import { CreateUser } from './components/dashboard/create-user/create-user';
import { EditTask } from './components/dashboard/edit-task/edit-task';
import { CreateTask } from './components/dashboard/create-task/create-task';

export const routes: Routes = [
    { path: "", component:Dashboard},
    { path:"home",component:Dashboard,
        children: [
            {path: 'users', component: UsersInfo },                
            {path: 'createUser', component: CreateUser},                                        
            {path: 'tasks', component: TasksInfo },                
            {path: 'createTask', component: CreateTask},
            {path: 'changeStatus/:id', component: EditTask},                                                  
        ],
    }
];

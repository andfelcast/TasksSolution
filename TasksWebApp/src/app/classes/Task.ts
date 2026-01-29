export interface Task extends TaskCreate{    
    creationDate:Date,        
    statusName:string,    
    userName:string,
    additionalInfo:string
}

export interface TaskCreate{
    id:number,
    name:string,    
    duration:number,
    statusId:number,    
    userId:number,    
}
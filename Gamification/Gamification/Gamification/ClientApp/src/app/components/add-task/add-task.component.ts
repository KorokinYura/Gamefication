import { Component, Inject, OnInit } from '@angular/core';
import { fadeInOut } from '../../services/animations';
import { ConfigurationService } from '../../services/configuration.service';
import { HttpClient } from '@angular/common/http';
import { Utilities } from '../../services/utilities';
import { AlertService, MessageSeverity } from '../../services/alert.service';
import { AccountService } from "../../services/account.service";
import { User } from '../../models/user.model';
import { Role } from '../../models/role.model';
import { setTimeout } from 'timers';

@Component({
  selector: 'app-add-task',
  templateUrl: './add-task.component.html',
  styleUrls: ['./add-task.component.scss']
})
export class AddTaskComponent {
  name: string;
  task: GameTask;

  constructor(private http: HttpClient) {
    this.task = new GameTask();
  }

  createTask() {

    this.postTask("tasks/create", this.task);
  }

  postTask(path: string, obj: GameTask) {
    this.http.post<Object>(location.origin + "/api/" + path, obj).subscribe(
      obj => {
        console.log(obj);
        location.reload();
      }, error => console.error(error));
  }
}


class GameTask {
  public id: number;
  public name: string;
  public description: string;
  public price: number;

  public timeLimit: Date;
}

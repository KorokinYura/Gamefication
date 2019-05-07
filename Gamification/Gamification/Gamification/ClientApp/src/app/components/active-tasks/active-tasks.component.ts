import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { formatDate } from '@angular/common';


import { AlertService, MessageSeverity } from '../../services/alert.service';
import { AccountService } from "../../services/account.service";
import { Utilities } from '../../services/utilities';
import { User } from '../../models/user.model';
import { Role } from '../../models/role.model';

@Component({
  selector: 'app-active-tasks',
  templateUrl: './active-tasks.component.html',
  styleUrls: ['./active-tasks.component.scss']
})
export class ActiveTasksComponent {
  tasks: GameTask[] = [];
  dates: string[] = [];
  idTask = 0;

  constructor(private http: HttpClient, private alertService: AlertService, private accountService: AccountService) {
    this.loadCurrentUserData();
  }


  getActiveGameTasks(path: string) {
    this.http.get(location.origin + "/api/" + path + "/" + this.user.id).subscribe(
      obj => {
        this.tasks = <GameTask[]>obj;
        console.log("Tasks: \n " + this.tasks);

        console.log(this.tasks.length);

        for (let i = 0; i < this.tasks.length; i++) {
          this.dates[i] = formatDate(this.tasks[i].timeLimit, "yyyy-MM-dd", "en-US");
        }

        if (this.tasks[0] != null)
          this.idTask = this.tasks[0].id;

      }, error => console.error(error));
  }
  





  user: User;

  private loadCurrentUserData() {
    this.alertService.startLoadingMessage();

    //this.accountService.getUserAndRoles().subscribe(results => this.onCurrentUserDataLoadSuccessful(results[0], results[1]), error => this.onCurrentUserDataLoadFailed(error));

    this.accountService.getUser().subscribe(user => this.onCurrentUserDataLoadSuccessful(user, user.roles.map(x => new Role(x))), error => this.onCurrentUserDataLoadFailed(error));
  }


  private onCurrentUserDataLoadSuccessful(user: User, roles: Role[]) {
    this.alertService.stopLoadingMessage();
    this.user = user;
    this.getActiveGameTasks("tasks/active");
  }

  private onCurrentUserDataLoadFailed(error: any) {
    this.alertService.stopLoadingMessage();
    this.alertService.showStickyMessage("Load Error", `Unable to retrieve user data from the server.\r\nErrors: "${Utilities.getHttpResponseMessage(error)}"`,
      MessageSeverity.error, error);

    this.user = new User();
  }
}

class GameTask {
  public id: number;
  public name: string;
  public description: string;
  public price: number;

  public timeLimit: Date;
}

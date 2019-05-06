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
  selector: 'app-inactive-tasks',
  templateUrl: './inactive-tasks.component.html',
  styleUrls: ['./inactive-tasks.component.scss']
})
export class InactiveTasksComponent implements OnInit {
  public num;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private alertService: AlertService, private accountService: AccountService) {
  }

  ngOnInit() {
    this.loadCurrentUserData();
  }

  getTasks(path: string) {
    let url = this.baseUrl + "/api/" + path;

    console.log("Path: " + url);


    this.http.get(url).subscribe(
      result => {
        this.num = result;

        console.log("Result: \n " + result);

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

    //console.log(">>>>>>>> Success");
    console.log(this.user);
    this.getTasks("tasks/user/" + this.user.userName);
  }

  private onCurrentUserDataLoadFailed(error: any) {
    this.alertService.stopLoadingMessage();
    this.alertService.showStickyMessage("Load Error", `Unable to retrieve user data from the server.\r\nErrors: "${Utilities.getHttpResponseMessage(error)}"`,
      MessageSeverity.error, error);

    //console.log(">>>>>>>> Error");

    this.user = new User();
  }
}

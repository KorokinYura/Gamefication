import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { formatDate } from '@angular/common';


import { AlertService, MessageSeverity } from '../../services/alert.service';
import { AccountService } from "../../services/account.service";
import { Utilities } from '../../services/utilities';
import { User } from '../../models/user.model';
import { Role } from '../../models/role.model';

@Component({
  selector: 'bonuses',
  templateUrl: './bonuses.component.html',
  styleUrls: ['./bonuses.component.scss']
})
export class BonusesComponent {
  bonuses: Bonus[] = [];
  dates: string[] = [];
  idBonus = 0;
  points;

  constructor(private http: HttpClient, private alertService: AlertService, private accountService: AccountService) {
    this.getBonuses("bonuses");
    this.loadCurrentUserData();
  }
  

  getBonuses(path: string) {
    this.http.get(location.origin + "/api/" + path).subscribe(
      obj => {
        this.bonuses = <Bonus[]>obj;
        console.log("Sets: \n " + this.bonuses);

        console.log(this.bonuses.length);

        for (let i = 0; i < this.bonuses.length; i++) {
          this.dates[i] = formatDate(this.bonuses[i].timeLimit, "yyyy-MM-dd", "en-US");
        }

        this.idBonus = this.bonuses[0].id;

      }, error => console.error(error));
  }


  buyBonus() {
    if (this.points > this.bonuses.find(b => b.id == this.idBonus).price)
      this.getBuyBonus("bonuses/buy", this.idBonus);
    else
      alert("You do not have enough points to buy " + this.bonuses.find(b => b.id == this.idBonus).name);
    //alert(this.user.id);
  }

  getPoints(path: string) {
    let url = location.origin + "/api/" + path;

    console.log("Path: " + url);


    this.http.get(url).subscribe(
      result => {
        this.points = result;

        console.log("Points: \n " + result);

      }, error => console.error(error));
  }



  getBuyBonus(path: string, obj: number) {
    if (this.idBonus === null || this.idBonus === undefined)
      return;

    this.http.get(location.origin + "/api/" + path + "/" + this.idBonus + "/" + this.user.id).subscribe(
      obj => {
        console.log(obj);
        if(obj == true)
          alert("Success");
        else
          alert("Error");

        location.reload();
      }, error => {
        console.error(error);
        //alert("Error: " + error);
        alert("Error");
      });
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
    this.getPoints("account/points/" + this.user.userName);
  }

  private onCurrentUserDataLoadFailed(error: any) {
    this.alertService.stopLoadingMessage();
    this.alertService.showStickyMessage("Load Error", `Unable to retrieve user data from the server.\r\nErrors: "${Utilities.getHttpResponseMessage(error)}"`,
      MessageSeverity.error, error);

    this.user = new User();
  }
}


class Bonus {
  public id: number;
  public name: string;
  public description: string;
  public price: number;
  public amount: number;

  public timeLimit: Date;
}

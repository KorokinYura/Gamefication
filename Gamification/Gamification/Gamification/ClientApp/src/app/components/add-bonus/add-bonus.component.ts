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
  selector: 'app-add-bonus',
  templateUrl: './add-bonus.component.html',
  styleUrls: ['./add-bonus.component.scss']
})

export class AddBonusComponent {
  name: string;
  bonus: Bonus;

  constructor(private http: HttpClient) {
    this.bonus = new Bonus();
  }

  createBonus() {

    this.postBonus("bonuses/create", this.bonus);
  }

  postBonus(path: string, obj: Bonus) {
    this.http.post<Object>(location.origin + "/api/" + path, obj).subscribe(
      obj => {
        console.log(obj);
        alert("Success");
        location.reload();
      }, error => console.error(error));
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

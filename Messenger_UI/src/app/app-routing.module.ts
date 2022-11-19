import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuardService } from './core/services/auth-guard.service';
import { HomeScreenService } from './core/services/home-screen.service';
import { MainComponent } from './layouts/main/main.component';
import { ComposeComponent } from './modules/compose/compose.component';
import { InboxComponent } from './modules/inbox/inbox.component';
import { LoginComponent } from './modules/login/login.component';
import { NotFoundComponent } from './utility/not-found/not-found.component';

const routes: Routes = [
  { path: '', component: LoginComponent, canActivate: [HomeScreenService] },
  { path: 'login', component: LoginComponent, canActivate: [HomeScreenService] },
  { path: 'inbox', component: InboxComponent, canActivate: [AuthGuardService] },
  { path: 'compose', component: ComposeComponent, canActivate: [AuthGuardService] },
  { path: '**', component: NotFoundComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

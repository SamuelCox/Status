import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule, Route } from '@angular/router';
import { LocalStorageModule } from 'angular-2-local-storage';
import { QuillModule } from 'ngx-quill'

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { UpdateMasterComponent } from './update-master/update-master.component';
import { UpdateDetailComponent } from './update-detail/update-detail.component';
import { UserComponent } from './user/user.component';
import { BlogMasterComponent } from './blog-master/blog-master.component';
import { BlogDetailComponent } from './blog-detail/blog-detail.component';
import { LoginComponent } from './login/login.component';
import { CreateUpdateComponent } from './create-update/create-update.component';
import { CreateBlogComponent } from './create-blog/create-blog.component';
import { AuthGuard } from './auth.guard';
import { RegisterComponent } from './register/register.component';
import { ReactiveFormsModule } from '@angular/forms';


const routes: Route[] = [
  { path: '', component: UpdateMasterComponent, canActivate: [AuthGuard], pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'blogs', component: BlogMasterComponent, canActivate: [AuthGuard] },
  { path: 'blogs/:id', component: BlogDetailComponent, canActivate: [AuthGuard] },
  { path: 'createblog', component: CreateBlogComponent, canActivate: [AuthGuard] },
  { path: 'updates', component: UpdateMasterComponent, canActivate: [AuthGuard] },
  { path: 'updates/:id', component: UpdateDetailComponent, canActivate: [AuthGuard] },
  { path: 'createupdate', component: CreateUpdateComponent, canActivate: [AuthGuard] },
  { path: 'user', component: UserComponent, canActivate: [AuthGuard] }
];

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    UpdateMasterComponent,
    UpdateDetailComponent,
    UserComponent,
    BlogMasterComponent,
    BlogDetailComponent,
    LoginComponent,
    CreateUpdateComponent,
    CreateBlogComponent,
    RegisterComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    LocalStorageModule.withConfig({
      prefix: 'status',
      storageType: 'localStorage'
    }),
    RouterModule.forRoot(routes),
    QuillModule.forRoot()
  ],
  providers: [AuthGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }

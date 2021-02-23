<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="BTS.PL.Forms.Registeration.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <asp:UpdatePanel ID="upContent" runat="server">
        <ContentTemplate>
            <asp:Panel ID="PnlMainRegisterationInfo" runat="server" Visible="true">
                <asp:CheckBoxList ID="cbxlstRegisterationTypes" runat="server" OnSelectedIndexChanged="cbxlstRegisterationTypes_SelectedIndexChanged" AutoPostBack="true">
                    <asp:ListItem Text="Consultant" Enabled="true" Selected="False" />
                    <asp:ListItem Text="User" Enabled="true" Selected="False" />
                </asp:CheckBoxList>
                <br />
                <br />
                <asp:Button ID="btnRegisterationTypes_Next" runat="server" Text="Next" Enabled="false" ValidationGroup="vgTypes"
                    OnClick="btnRegisterationTypes_Next_Click" CausesValidation="false" class="btn btn-primary" />
            </asp:Panel>
            <asp:Panel ID="PnlPersonalInfo" runat="server" Visible="false">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title" id="myModalLabel">Personal Info</h4>
                    </div>
                    <div class="modal-body">
                        <div class="col-md-2">
                            Email Address
                        </div>
                        <div class="col-md-10">
                            <asp:TextBox ID="txtPersonal_Email" runat="server" TextMode="Email"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPersonal_Email" ErrorMessage="*" ForeColor="Red"
                                ValidationGroup="vgPersonalInfo"></asp:RequiredFieldValidator>
                        </div>
                        <br />
                        <br />
                        <div class="col-md-2">
                            National ID / Passport Number
                        </div>
                        <div class="col-md-10">
                            <asp:TextBox ID="txtPersonal_NationalID" runat="server"></asp:TextBox>
                        </div>
                        <br />
                        <br />
                        <div class="col-md-2">
                            First Name
                        </div>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtPersonal_FirstName" runat="server" Width="100px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPersonal_FirstName" ErrorMessage="*" ForeColor="Red"
                                ValidationGroup="vgPersonalInfo"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-2">
                            Second Name
                        </div>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtPersonal_SecondName" runat="server" Width="100px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPersonal_SecondName" ErrorMessage="*" ForeColor="Red"
                                ValidationGroup="vgPersonalInfo"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-2">
                            Third Name
                        </div>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtPersonal_ThirdName" runat="server" Width="100px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPersonal_ThirdName" ErrorMessage="*" ForeColor="Red"
                                ValidationGroup="vgPersonalInfo"></asp:RequiredFieldValidator>
                        </div>
                        <br />
                        <br />
                        <div class="col-md-2">
                            Birthdate
                        </div>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtPersonal_Birthdate" runat="server" Width="100px" TextMode="Date"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            Mobile Number
                        </div>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtPersonal_MobileNO" runat="server" Width="100px"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            Phone Number
                        </div>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtPersonal_PhoneNO" runat="server" Width="100px"></asp:TextBox>
                        </div>
                        <br />
                        <br />
                        <div class="col-md-2">
                            Address
                        </div>
                        <div class="col-md-6">
                            <asp:TextBox ID="txtPersonal_Address" runat="server" Width="420px"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            Area
                        </div>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtPersonal_Area" runat="server" Width="100px"></asp:TextBox>
                        </div>
                        <br />
                        <br />
                        <div class="col-md-2">
                            Country
                        </div>
                        <div class="col-md-2">
                            <asp:DropDownList ID="ddlPersonal_Country" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPersonal_Country_SelectedIndexChanged" Width="100px"></asp:DropDownList>
                        </div>
                        <div class="col-md-2">
                            Province
                        </div>
                        <div class="col-md-2">
                            <asp:DropDownList ID="ddlPersonal_Province" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPersonal_Province_SelectedIndexChanged" Width="100px"></asp:DropDownList>
                        </div>
                        <div class="col-md-2">
                            City
                        </div>
                        <div class="col-md-2">
                            <asp:DropDownList ID="ddlPersonal_City" runat="server" Width="100px">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlPersonal_City" ErrorMessage="*" ForeColor="Red"
                                ValidationGroup="vgPersonalInfo"></asp:RequiredFieldValidator>
                        </div>
                        <br />
                        <br />
                        <div class="col-md-2">
                            Company Name
                        </div>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtPersonal_CompanyName" runat="server" Width="100px"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            Address
                        </div>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtPersonal_CompanyAddress" runat="server" Width="100px"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            Area
                        </div>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtPersonal_CompanyArea" runat="server" Width="100px"></asp:TextBox>
                        </div>
                        <br />
                        <br />
                        <div class="col-md-2">
                            Company Country
                        </div>
                        <div class="col-md-2">
                            <asp:DropDownList ID="ddlPersonal_CompanyCountry" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPersonal_CompanyCountry_SelectedIndexChanged" Width="100px"></asp:DropDownList>
                        </div>
                        <div class="col-md-2">
                            Company Province
                        </div>
                        <div class="col-md-2">
                            <asp:DropDownList ID="ddlPersonal_CompanyProvince" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPersonal_CompanyProvince_SelectedIndexChanged" Width="100px"></asp:DropDownList>
                        </div>
                        <div class="col-md-2">
                            Company City
                        </div>
                        <div class="col-md-2">
                            <asp:DropDownList ID="ddlPersonal_CompanyCity" runat="server" Width="100px">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddlPersonal_CompanyCity" ErrorMessage="*" ForeColor="Red"
                                ValidationGroup="vgPersonalInfo"></asp:RequiredFieldValidator>
                        </div>
                        <br />
                        <br />
                        <div class="col-md-2">
                            Photo
                        </div>
                        <div class="col-md-6">
                            <asp:FileUpload ID="fuPersonal_Image" runat="server" Width="400px"></asp:FileUpload>
                        </div>
                        <div class="col-md-2">
                        </div>
                        <div class="col-md-2">
                        </div>
                        <br />
                        <br />
                        <div class="col-md-2" runat="server" id="divBankCountry">
                            Bank Country
                        </div>
                        <div class="col-md-2" runat="server" id="divBankCountryValue">
                            <asp:DropDownList ID="ddlPersonal_BankCountry" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPersonal_BankCountry_SelectedIndexChanged" Width="100px">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="ddlPersonal_BankCountry"
                                Text="*" ErrorMessage="*" ValidationGroup="vgPersonalInfo" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-2" runat="server" id="divBankCode">
                            Bank Code
                        </div>
                        <div class="col-md-2" runat="server" id="divBankCodeValue">
                            <asp:DropDownList ID="ddlPersonal_Bank" runat="server" Width="100px"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvPersonal_Bank" runat="server" ControlToValidate="ddlPersonal_Bank"
                                Text="*" ErrorMessage="*" ValidationGroup="vgPersonalInfo" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-2" runat="server" id="divBankAccountNO">
                            Bank Account NO.
                        </div>
                        <div class="col-md-2" runat="server" id="divBankAccountNOValue">
                            <asp:TextBox ID="txtPersonal_BankAccountNO" runat="server" Width="100px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtPersonal_BankAccountNO"
                                Text="*" ErrorMessage="*" ValidationGroup="vgPersonalInfo" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        <br />
                        <br />
                        <div class="col-md-2">
                            Password
                        </div>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtPersonal_Password" runat="server" Width="100px" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtPersonal_Password" ErrorMessage="*" ForeColor="Red"
                                ValidationGroup="vgPersonalInfo"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-2">
                            Password Confirmation
                        </div>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtPersonal_PasswordConfirmation" runat="server" Width="100px" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtPersonal_PasswordConfirmation" ErrorMessage="*" ForeColor="Red"
                                ValidationGroup="vgPersonalInfo"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="cv1" runat="server" ControlToValidate="txtPersonal_PasswordConfirmation"
                                ControlToCompare="txtPersonal_Password" Text="*" ForeColor="Red" ValidationGroup="vgPersonalInfo"></asp:CompareValidator>
                        </div>
                        <div class="col-md-2">
                        </div>
                        <div class="col-md-2">
                        </div>
                        <br />
                        <br />
                        <br />
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnPersonal_Cancel" runat="server" Text="Cancel" OnClick="btnPersonal_Cancel_Click" CausesValidation="false" class="btn btn-default" data-dismiss="modal" />
                        <asp:Button ID="btnPersonal_Next" runat="server" Text="Next" OnClick="btnPersonal_Next_Click" ValidationGroup="vgPersonalInfo" CausesValidation="true" class="btn btn-primary" />
                    </div>
                </div>
            </asp:Panel>
            <asp:Panel ID="PnlCountries" runat="server" Visible="false">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title" id="myModalLabel">Available Countries</h4>
                    </div>
                    <div class="modal-body">
                        <div class="col-md-2">
                            Country
                        </div>
                        <div class="col-md-5">
                            <asp:DropDownList ID="ddlAvailableCountries" runat="server"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddlAvailableCountries" ErrorMessage="*" ForeColor="Red"
                                ValidationGroup="vgAvailableCountries"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-5">
                            <asp:Button ID="btnAddAvailableCountry" runat="server" Text="Add" OnClick="btnAddAvailableCountry_Click" ValidationGroup="vgAvailableCountries" CausesValidation="true" class="btn btn-primary" />
                        </div>
                        <br />
                        <br />
                        <br />
                        <asp:GridView ID="gvAvailableCountries" runat="server" CssClass="table table-responsive" AutoGenerateColumns="false"
                            BorderWidth="0" HeaderStyle-BackColor="#e2e2e2">
                            <Columns>
                                <asp:BoundField DataField="CountryCode" Visible="false" />
                                <asp:BoundField DataField="CountryName" HeaderText="Country Name" />
                                <asp:TemplateField HeaderText="Is Primary">
                                    <ItemTemplate>
                                        <div>
                                            <asp:HiddenField runat="server" Value='<%#Eval("CountryCode") %>' />
                                            <asp:CheckBox ID="cbxSelectedItemIsActive" Font-Bold="true" runat="server" SelectedID='<%# Eval("CountryCode") %>'
                                                Checked='<%# Eval("IsPrimary") %>' AutoPostBack="true"
                                                OnCheckedChanged="cbxSelectedItemIsActive_CheckedChanged" />
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delete">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnDelete" runat="server" SelectedID='<%# Eval("CountryCode") %>'
                                            Visible='<%# !bool.Parse(Eval("IsPrimary").ToString()) %>'
                                            CausesValidation="false" OnClick="btnDelete_Click"
                                            ImageUrl="~/client/images/delitem.gif" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnCountry_Back" runat="server" Text="Back" OnClick="btnCountry_Back_Click" CausesValidation="false" class="btn btn-default" data-dismiss="modal" />
                        <asp:Button ID="btnCountry_Next" runat="server" Text="Next" OnClick="btnCountry_Next_Click" Enabled="false" ValidationGroup="vgAvailableCountries1" CausesValidation="true" class="btn btn-primary" />
                    </div>
                </div>
            </asp:Panel>
            <asp:Panel ID="PnlExpertiseRCLInfo" runat="server" Visible="false">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title" id="myModalLabel">Expertises Info</h4>
                    </div>
                    <div class="modal-body">
                        <div class="col-md-2">
                            Main Expertises
                        </div>
                        <div class="col-md-2">
                            <asp:DropDownList ID="ddlExpertises_Main" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlExpertises_Main_SelectedIndexChanged"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="ddlExpertises_Main" ErrorMessage="*" ForeColor="Red"
                                ValidationGroup="vgExpertises"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-2">
                            Child Expertises
                        </div>
                        <div class="col-md-2">
                            <asp:DropDownList ID="ddlExpertises_Child" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlExpertises_Child_SelectedIndexChanged"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="ddlExpertises_Child" ErrorMessage="*" ForeColor="Red"
                                ValidationGroup="vgExpertises"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-2">
                            Expertise Level
                        </div>
                        <div class="col-md-2">
                            <asp:DropDownList ID="ddlRCL" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlRCL_SelectedIndexChanged"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="ddlRCL" ErrorMessage="*" ForeColor="Red"
                                ValidationGroup="vgExpertises"></asp:RequiredFieldValidator>
                        </div>
                        <br />
                        <br />
                        <div class="col-md-2">
                            Cost (LE.)
                        </div>
                        <div class="col-md-2">
                            <asp:Label ID="lblExpertiseRCLCost" runat="server"></asp:Label>
                        </div>
                        <div class="col-md-8">
                            <asp:Button ID="btnAddExpertise" runat="server" Text="Add" OnClick="btnAddExpertise_Click" ValidationGroup="vgExpertises" CausesValidation="true" class="btn btn-primary" />
                        </div>
                        <br />
                        <br />
                        <br />
                        <asp:GridView ID="gvExpertiseRCL" runat="server" CssClass="table table-responsive" AutoGenerateColumns="false"
                            BorderWidth="0" HeaderStyle-BackColor="#e2e2e2">
                            <Columns>
                                <asp:BoundField DataField="Code" Visible="false" />
                                <asp:BoundField DataField="MainExpertiseName" HeaderText="Main Expertise" />
                                <asp:BoundField DataField="ChildExpertiseName" HeaderText="Child Expertise" />
                                <asp:BoundField DataField="RCLName" HeaderText="Expertise Level" />
                                <asp:BoundField DataField="Cost" HeaderText="Cost" />
                                <asp:TemplateField HeaderText="Delete">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnDeleteExpertiseRCL" runat="server" SelectedID='<%# Eval("Code") %>'
                                            CausesValidation="false" OnClick="btnDeleteExpertiseRCL_Click"
                                            ImageUrl="~/client/images/delitem.gif" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnExpertise_Back" runat="server" Text="Back" OnClick="btnExpertise_Back_Click" CausesValidation="false" class="btn btn-default" data-dismiss="modal" />
                        <asp:Button ID="btnExpertise_Save" runat="server" Text="Next" OnClick="btnExpertise_Save_Click" Enabled="false" ValidationGroup="vgExpertise1" CausesValidation="true" class="btn btn-primary" />
                    </div>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

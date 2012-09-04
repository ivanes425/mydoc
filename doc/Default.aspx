<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Lifecare</title>
    <link href="style.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="js/jquery.min.js"></script>

    <script type="text/javascript">

        $(document).ready(function() {

            //Default Action
            $(".tab_content").hide(); //Hide all content
            $("ul.tabs li:first").addClass("active").show(); //Activate first tab
            $(".tab_content:first").show(); //Show first tab content

            //On Click Event
            $("ul.tabs li").click(function() {
                $("ul.tabs li").removeClass("active"); //Remove any "active" class
                $(this).addClass("active"); //Add "active" class to selected tab
                $(".tab_content").hide(); //Hide all tab content
                var activeTab = $(this).find("a").attr("href"); //Find the rel attribute value to identify the active tab + content
                $(activeTab).fadeIn(); //Fade in the active content
                return false;
            });

        });
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div id="maindiv">
        <div id="contentmain">
            <!--header section-->
            <div id="header">
                <div id="logodiv">
                    <div id="logo">
                        <img src="images/logo.jpg" width="271" height="96" title="Lifecare" alt="Lifecare" />
                    </div>
                    <div class="topmenu">
                        <div id="tabs22">
                            <ul>
                                <li><a href="#" title="Link 1"><span>Medical News</span></a></li>
                                <li><a href="#" title="Link 2"><span>Find a Doctor</span></a></li>
                                <li><a href="#" title="Link 3"><span>Health Centers</span></a></li>
                                <li><a href="#" title="Longer Link Text"><span>Register</span></a></li>
                                <li><a href="javascript:void(0)" onclick="document.getElementById('light').style.display='block';document.getElementById('fade').style.display='block'">
                                    <span>Sign-In</span></a></li>
                            </ul>
                            <ul>
                                <div class="socialicons">
                                    Stay Connected with us:<br />
                                    <img src="images/tweeticon.jpg" width="30" height="30" title="" alt="" />
                                    <img src="images/linkedinIcon.jpg" width="30" height="30" title="" alt="" />
                                    <img src="images/facebookicon.jpg" width="30" height="30" title="" alt="" />
                                    <img src="images/addthisicon.jpg" width="30" height="30" title="" alt="" />
                                </div>
                                <div class="clear">
                                </div>
                            </ul>
                        </div>
                    </div>
                    <div id="topright">
                        <div class="advancedsearch">
                            <img src="images/magnifire.jpg" width="25" height="24" title="" alt="" />
                            <img src="images/AdvancedSearch.jpg" width="138" height="24" title="" alt="" /></div>
                        <div id="toprightlinks">
                            <div class="linksdiv">
                                <img src="images/askIcon.jpg" width="21" height="19" align="top" title=" " alt="" />
                                Ask an Expert</div>
                            <br />
                            <div class="linksdiv">
                                <img src="images/bulbIcon.jpg" width="21" height="19" align="top" title=" " alt="" />
                                Get a Professional Answer</div>
                            <br />
                            <div class="linksdiv">
                                <img src="images/100perIcon.jpg" width="21" height="19" title="" alt="" align="top" />
                                100% Satisfaction Guarantee</div>
                            <br />
                        </div>
                    </div>
                </div>
                <div id="bannerdiv">
                    <div id="banner">
                        <img src="images/banner.jpg" width="652" height="218" title="" alt="" />
                    </div>
                    <div id="search">
                        <div id="searchform">
                            <div class="textser">
                                Select Department
                            </div>
                            <div class="searchfield">
                                <select name="seldep" id="seldep">
                                    <option value="">--Select one--</option>
                                    <option value="">Dep</option>
                                </select>
                            </div>
                            <div class="textser">
                                Select City
                            </div>
                            <div class="searchfield">
                                <select name="seldep2" id="seldep2">
                                    <option value="">--Select one--</option>
                                    <option value="">Dep</option>
                                </select>
                            </div>
                            <div class="textser">
                                Select Area
                            </div>
                            <div class="searchfield">
                                <select name="seldep3" id="seldep3">
                                    <option value="">--Select one--</option>
                                    <option value="">Dep</option>
                                </select>
                            </div>
                            <div class="textser">
                                Do you have Health
                                <br />
                                Insurance
                            </div>
                            <div class="searchfield">
                                <input name="yes" type="radio" value="y" />Yes
                                <input name="no" type="radio" value="n" />No
                            </div>
                        </div>
                        <div class="btn">
                            <img src="images/finddoctors.png" width="117" height="29" title="" alt="" /></div>
                    </div>
                </div>
                <div class="menu">
                    <div id="nav-menu">
                        <ul>
                            <li><a href="#">Home</a></li>
                            <li><a href="#">About us</a></li>
                            <li><a href="#">Our Services</a></li>
                            <li><a href="#">Specialists Search</a></li>
                            <li><a href="#">Request Appointment</a></li>
                            <li><a href="#">Local Directory</a></li>
                            <li><a href="#">Health Insurance</a></li>
                            <li><a href="#">Contact Us</a></li>
                        </ul>
                    </div>
                </div>
            </div>
            <div class="clear">
            </div>
            <!--header section end-->
            <div id="content">
                <div id="tabsdiv">
                    <div class="container">
                        <ul class="tabs">
                            <li><a href="#tab1">Get Health Info &amp; Tips</a></li>
                            <li><a href="#tab2">General Health Questions</a></li>
                            <li><a href="#tab3">Offers &amp; Promotions</a></li>
                            <li><a href="#tab4">Pharmacy</a></li>
                        </ul>
                        <div class="tab_container">
                            <div id="tab1" class="tab_content">
                                <p>
                                    <img src="images/tabimage.jpg" width="147" height="106" align="middle" title="" alt="" />
                                    We all know "prevention is better than cure". At our Life Care Pharmacy we recognize
                                    the importance and need for preventive healthcare.
                                </p>
                                <p>
                                    Comprehensive check-ups screen and detect even the smallest symptom that could be
                                    an indication of a major disease. Our health check-up packages are tailor made for
                                    you and your family to have healthy future.
                                </p>
                                <p>
                                    <a style="background-color:#DE4221;padding:5px;color:White" href="#">Normal parameters</a>&nbsp;&nbsp;
                                    <a style="background-color:#DE4221;padding:5px;color:White" href="#">BMI calculation</a>&nbsp;&nbsp;
                                    <a style="background-color:#DE4221;padding:5px;color:White" href="#">C/F converter</a>&nbsp;&nbsp;
                                    <a style="background-color:#DE4221;padding:5px;color:White" href="#">Health tips</a>
                                </p>
                            </div>
                            <div id="tab2" class="tab_content">
                                <h2>
                                    General Health Questions</h2>
                                <p>
                                    Grandma been has bankrupt said hospitality fence everlastin' wrestlin' rodeo redblooded
                                    chitlins marshal. Boobtube soap her hootch lordy cow, rattler.
                                </p>
                                <p>
                                    Rottgut havin' ignorant go, hee-haw shiney jail fetched hillbilly havin' cipherin'.
                                    Bacon no cowpoke tobaccee horse water rightly trailer tools git hillbilly.
                                </p>
                                <p>
                                    Jezebel had whiskey snakeoil, askin' weren't, skanky aunt townfolk fetched. Fit
                                    tractor, them broke askin', them havin' rattler fell heffer, been tax-collectors
                                    buffalo. Quarrel confounded fence wagon trailer, moonshine wuz, city-slickers fixin'
                                    cow.
                                </p>
                            </div>
                            <div id="tab3" class="tab_content">
                                <h2>
                                    Offers &amp; Promotions</h2>
                                <p>
                                    Dirt tools thar, pot buffalo put jehosephat rent, ya pot promenade. Come pickled
                                    far greasy fightin', wirey, it poor yer, drive jig landlord. Rustle is been moonshine
                                    whomp hogtied. Stew, wirey stew cold uncle ails. Slap hoosegow road cooked, where
                                    gal pot, commencin' country. Weren't dogs backwoods, city-slickers me afford boxcar
                                    fat, dumb sittin' sittin' drive rustle slap, tornado. Fuss stinky knickers whomp
                                    ain't, city-slickers sherrif darn ignorant tobaccee round-up old buckshot that.
                                </p>
                                <p>
                                    Deep-fried over shootin' a wagon cheatin' work cowpoke poor, wuz, whiskey got wirey
                                    that. Shot beer, broke kickin' havin' buckshot gritts. Drunk, em moonshine his commencin'
                                    country drunk chitlins stole. </p>
                            </div>
                            <div id="tab4" class="tab_content">
                                <h2>
                                    Pharmacy</h2>
                                <p>
                                    Grandma been has bankrupt said hospitality fence everlastin' wrestlin' rodeo redblooded
                                    chitlins marshal. Boobtube soap her hootch lordy cow, rattler.
                                </p>
                                <p>
                                    Rottgut havin' ignorant go, hee-haw shiney jail fetched hillbilly havin' cipherin'.
                                    Bacon no cowpoke tobaccee horse water rightly trailer tools git hillbilly.
                                </p>
                                <p>
                                    Jezebel had whiskey snakeoil, askin' weren't, skanky aunt townfolk fetched. Fit
                                    tractor, them broke askin', them havin' rattler fell heffer, been tax-collectors
                                    buffalo. Quarrel confounded fence wagon trailer, moonshine wuz, city-slickers fixin'
                                    cow.
                                </p>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="clear">
                </div>
                <div id="searchmenus">
                    <div id="clinicsearch">
                        <div class="searchimg">
                            <img src="images/clinicsearch.jpg" width="203" height="80" title="" alt="" /></div>
                        <div class="searchlinks">
                            <ul>
                                <li><a href="#">Allergy &amp; Immunology</a></li>
                                <li><a href="#">Anesthesiology</a></li>
                                <li><a href="#">Ayurveda</a></li>
                                <li><a href="#">Dentistry</a></li>
                                <li><a href="#">more...</a></li>
                            </ul>
                        </div>
                    </div>
                    <div id="specialistsearch">
                        <div class="searchimg">
                            <img src="images/specialistsearch.jpg" width="203" height="80" title="" alt="" /></div>
                        <div class="searchlinks">
                            <ul>
                                <li><a href="#">Interventional Cardiology</a></li>
                                <li><a href="#">Obstetrics and Gynecology</a></li>
                                <li><a href="#">Midwife</a></li>
                                <li><a href="#">Neurological Surgery</a></li>
                                <li><a href="#">more...</a></li>
                            </ul>
                        </div>
                    </div>
                    <div id="requestappointment">
                        <div class="searchimg">
                            <img src="images/requestappointment.jpg" width="203" height="80" title="" alt="" /></div>
                        <div class="searchlinks">
                            <ul>
                                <li><a href="#">Psychiatry</a></li>
                                <li><a href="#">Pharmacists</a></li>
                                <li><a href="#">Plastic Surgery</a></li>
                                <li><a href="#">Radiology</a></li>
                                <li><a href="#">more...</a></li>
                            </ul>
                        </div>
                    </div>
                    
                    <div class="proregistration">
                        <img src="images/productregistration.jpg" width="234" height="65" title="" alt="" /></div>
                    <div class="pharmacy">
                        <img src="images/findapharmacy.jpg" width="234" height="65" title="" alt="" /></div>
                    </div>
            </div>
            <div id="sidebar">
                <div class="usefulbox">
                    <div class="usefulboxheding">
                        <p>
                            Useful Guides</p>
                    </div>
                    <div class="usefulboxtext">
                        <ul>
                            <li><a href="#">Brain and neurology guide</a></li>
                            <li><a href="#">Breast implants guide</a></li>
                            <li><a href="#">Cancer treatment guide</a></li>
                            <li><a href="#">Cosmetic dentistry guide</a></li>
                            <li><a href="#">Cosmetic surgery guide</a></li>
                            <li><a href="#">Dental disorders guide</a></li>
                        </ul>
                    </div>
                    <div class="usefulboxmore">
                        <p>
                            [more]</p>
                    </div>
                </div>
                <div class="clear"></div>
                
                <div style="margin-top:10px;" class="usefulbox">
                    <div class="usefulboxheding">
                        <p>
                            News &amp; Headlines</p>
                    </div>
                    <div class="usefulboxtext">
                        <p id="date">
                            Tuesday, 23 Aug 2011</p>
                        <p id="newsheading">
                            JCI reaffirms – Medinova's quality standards</p>
                        <p id="newsdetails">
                            The Diagnostic Center under the vertical of DM Healthcare is the first in the Middle
                            East to get the accreditation, and complete the reaccreditation process with JCI</p>
                    </div>
                    <div class="usefulboxmore">
                        <p>[more]</p>
                    </div>
                </div>
                <div class="clear">
                </div>
                <div style="margin-top:10px;">
                    <div id="fb-root"></div>
                    <script>                                
                        (function(d, s, id) {
                            var js, fjs = d.getElementsByTagName(s)[0];
                            if (d.getElementById(id)) { return; }
                            js = d.createElement(s); js.id = id;
                            js.src = "//connect.facebook.net/en_US/all.js#xfbml=1";
                            fjs.parentNode.insertBefore(js, fjs);
                        } (document, 'script', 'facebook-jssdk'));
                    </script>
                    <div class="fb-like-box" data-href="http://www.facebook.com/MethaqTakaful" 
                        data-width="280" data-show-faces="true" 
                        data-stream="false" data-header="false" 
                        border_color="#CDDEE8" height="170">
                    </div>                    
                </div>
            </div>
            <div class="clear">
            </div>
            <div class="contentfront">
                Lifecare helps people make informed decisions about lifecare services and providers
                by providing information and medical websites resources which are current, and comprehensive.
                The site embraces all aspects of private health care services, including private
                hospitals, private doctors and specialists, private medical insurance, cosmetic
                surgery, dentistry, and care of the elderly. There's also information on services
                such as <em><strong>DNA testing, health screening, private nursing care, private maternity
                    services, private physiotherapists, sports injury clinics and travel health clinics.</strong></em>
            </div>
            <div class="clear">
            </div>
            <div class="linebg">
                &nbsp;</div>
            <div class="clear">
            </div>
            <div id="footerdiv">
                <div class="footerwidgets">
                    <h1>
                        Quick links</h1>
                    <ul>
                        <li>Diseases &amp; Conditions</li>
                        <li>Healthy Living</li>
                        <li>Tools &amp; Resources</li>
                        <li>Community &amp; Advice</li>
                        <li>Industry Medical Portal</li>
                        <li>Student Centre</li>
                    </ul>
                </div>
                <div class="footerwidgets">
                    <h1>
                        Tools &amp; Resources</h1>
                    <ul>
                        <li>Health Resources</li>
                        <li>Health Calculators</li>
                        <li>Medical Calculators</li>
                        <li>Online Consultation</li>
                        <li>Drug Guide</li>
                        <li>Health News</li>
                    </ul>
                </div>
                <div class="footerwidgets">
                    <h1>
                        Links</h1>
                    <ul>
                        <li>Home</li>
                        <li>Abouts Us</li>
                        <li>Help</li>
                        <li>FAQ</li>
                        <li>Disclaimer &amp; Legal</li>
                        <li>Contact Us</li>
                    </ul>
                </div>
            </div>
            <div class="clear">
            </div>
            <div id="footer">
                <div id="copyright">
                    Copyright © 2011 Life Care. All Rights Reserved.</div>
                <div id="signup">
                    <img src="images/signup.jpg" width="149" height="31" title="" alt="" /></div>
            </div>
        </div>
    </div>
    <div id="light" class="white_content">
        <a href="javascript:void(0)" onclick="document.getElementById('light').style.display='none';document.getElementById('fade').style.display='none'">
            <img src="images/close-popup.gif" class="close" />
        </a>
        
        <h3>Enter your Login Details to access your personalized health records</h3>
        <div class="clear"></div>
        <div id="login">
            <p>
                <label>
                    <b>Username</b>
                </label>
                <span><asp:TextBox ID="UserNameTextBox" CssClass="LoginTextBox" runat="server"></asp:TextBox></span>
            </p>
            <div class="clear"></div>
        
            <p>
                <label><b>Password</b></label>
            </p>
            <span>
                <asp:TextBox ID="PasswordTextBox" CssClass="LoginTextBox" runat="server"></asp:TextBox>
            </span>
            <div class="links">
                <dl>
                    <dt>
                        <asp:LinkButton ID="ForgotPassButton" CssClass="link" runat="server" Text="Forgot Password?"></asp:LinkButton>    
                    </dt>
                    <dd>
                        <asp:LinkButton ID="RegisterButton" CssClass="link" runat="server" Text="New User?"></asp:LinkButton>    
                    </dd>
                    <img src="images/finddoctors.png" class="img" alt="Login" />
                </dl>
            </div>        
        </div>  
        
    </div>
    <div id="fade" class="black_overlay">
    </div>
    </form>
</body>
</html>

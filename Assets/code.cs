using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Code : MonoBehaviour
{
    private UpDown upDown; // UpDown sınıfına referans
    public Skill lightSkill;  // Light becerisi için referans
    public Skill laserSkill;  // Laser becerisi için referans
    public Button lightButton; // Light skill butonu
    public Button laserButton; // Laser skill butonu

    // Yeni Ses Kaynakları
    public AudioSource knifeAudioSource;
    public AudioSource fireAudioSource;
    public AudioSource lightAudioSource;
    public AudioSource laserAudioSource;
    public AudioSource jumpAudioSource;
    public AudioSource shieldAudioSource;
    public AudioSource cloneAudioSource;
    public AudioSource portalAudioSource;
    public AudioSource kamyonAudioSource;
    public AudioSource karakterAudioSource;

    // Ses dosyaları
    public AudioClip knifeSound;
    public AudioClip fireSound;
    public AudioClip lightSound;
    public AudioClip laserSound;
    public AudioClip jumpSound;
    public AudioClip shieldSound;
    public AudioClip cloneSound;
    public AudioClip portalSound;
    public AudioClip kamyonSound;
    public AudioClip karakterSound;


    // Her buton için bekleme süresi kontrolü
    private bool canClickKnife = true;
    private bool canClickFire = true;
    private bool canClickJump = true;
    private bool canClickShield = true;
    private bool canClickClone = true;
    private bool canClickPortal = true;
    private bool canClickLight = true;
    private bool canClickLaser = true;

    // Her buton için progress çubuğu Image'leri
    public Image knifeProgressImage;  // Knife butonunun etrafındaki çember
    public Image fireProgressImage;   // Fire butonunun etrafındaki çember
    public Image jumpProgressImage;   // Jump butonunun etrafındaki çember
    public Image shieldProgressImage; // Shield butonunun etrafındaki çember
    public Image cloneProgressImage;  // Clone butonunun etrafındaki çember
    public Image portalProgressImage; // Portal butonunun etrafındaki çember
    public Image lightProgressImage;  // Light butonunun etrafındaki çember
    public Image laserProgressImage;  // Laser butonunun etrafındaki çember

    void Start()
    {
        upDown = FindObjectOfType<UpDown>();
        if (upDown == null)
        {
            Debug.LogError("UpDown bileşeni bulunamadı!");
        }

        // Becerileri yükle ve butonları kontrol et
        lightSkill.LoadSkill();
        laserSkill.LoadSkill();
        UpdateSkillButtons();
    }

    private void UpdateSkillButtons()
    {
        // Light skill için butonun aktifliğini ayarla
        if (lightSkill != null && lightButton != null)
        {
            lightButton.interactable = lightSkill.isUnlocked; // Eğer skill açık değilse buton pasif olur
        }

        // Laser skill için butonun aktifliğini ayarla
        if (laserSkill != null && laserButton != null)
        {
            laserButton.interactable = laserSkill.isUnlocked; // Eğer skill açık değilse buton pasif olur
        }
    }

    private IEnumerator WaitForNextClick(float delay, string skill)
    {
        // İlgili progress çubuğunu başlat
        Image progressImage = GetProgressImage(skill);
        if (progressImage != null)
        {
            progressImage.fillAmount = 0; // Başlangıçta boş olsun
        }

        float elapsedTime = 0f;

        // Butonları tıklama durumu kontrol et
        switch (skill)
        {
            case "knife": canClickKnife = false; break;
            case "fire": canClickFire = false; break;
            case "jump": canClickJump = false; break;
            case "shield": canClickShield = false; break;
            case "clone": canClickClone = false; break;
            case "portal": canClickPortal = false; break;
            case "light": canClickLight = false; break;
            case "laser": canClickLaser = false; break;
        }

        // Progress çubuğunu güncelle
        while (elapsedTime < delay)
        {
            elapsedTime += Time.deltaTime;
            if (progressImage != null)
            {
                progressImage.fillAmount = Mathf.Clamp01(elapsedTime / delay); // Progress çubuğunu güncelle
            }
            yield return null;
        }

        // Süre bitince progress çubuğunu tamamla (1 yap)
        if (progressImage != null)
        {
            progressImage.fillAmount = 1; // Progress çubuğunu 1 yap
        }

        // Butonlar tekrar aktif olmalı
        switch (skill)
        {
            case "knife": canClickKnife = true; break;
            case "fire": canClickFire = true; break;
            case "jump": canClickJump = true; break;
            case "shield": canClickShield = true; break;
            case "clone": canClickClone = true; break;
            case "portal": canClickPortal = true; break;
            case "light": canClickLight = true; break;
            case "laser": canClickLaser = true; break;
        }
    }

    private Image GetProgressImage(string skillName)
    {
        switch (skillName)
        {
            case "knife": return knifeProgressImage;
            case "fire": return fireProgressImage;
            case "jump": return jumpProgressImage;
            case "shield": return shieldProgressImage;
            case "clone": return cloneProgressImage;
            case "portal": return portalProgressImage;
            case "light": return lightProgressImage;
            case "laser": return laserProgressImage;
            default: return null;
        }
    }

    private void TryPerformSkill(System.Action skillAction, AudioSource audioSource, AudioClip audioClip, float delay, string skillName)
    {
        if (upDown != null && GetSkillStatus(skillName))
        {
            audioSource.PlayOneShot(audioClip); // Ses çalma
            skillAction.Invoke();
            StartCoroutine(WaitForNextClick(delay, skillName));  // Belirtilen süre kadar bekle
        }
    }

    private bool GetSkillStatus(string skillName)
    {
        switch (skillName)
        {
            case "knife": return canClickKnife;
            case "fire": return canClickFire;
            case "jump": return canClickJump;
            case "shield": return canClickShield;
            case "clone": return canClickClone;
            case "portal": return canClickPortal;
            case "light": return canClickLight && lightSkill.isUnlocked;
            case "laser": return canClickLaser && laserSkill.isUnlocked;
            default: return false;
        }
    }

    // Knife butonunu tıklama işlevi
    public void knifebtn() => TryPerformSkill(() => upDown.ThrowKnife(), knifeAudioSource, knifeSound, 0.4f, "knife");

    // Fire butonunu tıklama işlevi
    public void firebtn() => TryPerformSkill(() => upDown.ThrowFire(), fireAudioSource, fireSound, 0.5f, "fire");

    // Jump butonunu tıklama işlevi
    public void jumpbtn() => TryPerformSkill(() => upDown.Jump(), jumpAudioSource, jumpSound, 0.5f, "jump");

    // Shield butonunu tıklama işlevi
    public void shieldbtn() => TryPerformSkill(() => StartCoroutine(upDown.ActivateShield()), shieldAudioSource, shieldSound, 0.5f, "shield");

    // Clone butonunu tıklama işlevi
    public void clonebtn() => TryPerformSkill(() => upDown.ClonePlayer(), cloneAudioSource, cloneSound, 0.5f, "clone");

    // Portal butonunu tıklama işlevi
    public void portalbtn()
    {
        // Debug: butonun tıklanıp tıklanmadığını kontrol et
        Debug.Log("Portal button clicked.");

        // Skill'i dene
        TryPerformSkill(() => upDown.PortalPlayer(), portalAudioSource, portalSound, 0.7f, "portal");
    }

    // Light skill butonunu tıklama işlevi
    public void lightbtn() => TryPerformSkill(() => upDown.LightPlayer(), lightAudioSource, lightSound, 0.1f, "light");

    // Laser skill butonunu tıklama işlevi
    public void laserbtn() => TryPerformSkill(() => upDown.LaserPlayer(), laserAudioSource, laserSound, 0.1f, "laser");

    // Kamyon butonunu tıklama işlevi
    public void arababtn()
    {
        // Ses çalma
        kamyonAudioSource.PlayOneShot(kamyonSound);

        // araba aktivasyon işlemi
        StartCoroutine(upDown.Activatearaba());
    }
    public void karakterbtn()
    {
        // Ses çalma
        karakterAudioSource.PlayOneShot(karakterSound);

        // karakter aktivasyon işlemi
        StartCoroutine(upDown.Activatekarakter());
    }
}

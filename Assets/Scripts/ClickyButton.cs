using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
//Mục tiêu của lớp thay đổi hình ảnh của nút bấm khi bấm vào và thả ra
public class ClickyButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    //Lưu hình ảnh của nút bấm 
    [SerializeField] private Image _img;
    //Lưu giữ hoạt ảnh ở dạnh thường và dạng được ấn của nút
    [SerializeField] private Sprite _default, _pressed;
    //Lưu giữ thông tin của âm thanh _compressClip và _uncompressClip
    [SerializeField] private AudioClip _compressClip, _uncompressClip;
    //Lưu giữ component audio soure của gameobject
    [SerializeField] private AudioSource _source;
    //Hàm bắt sự kiện bấm chuột của người dùng
    public void OnPointerDown(PointerEventData eventData)
    {
        //Thay đổi hoạt ảnh của nút bấm thành dạng đã bấm
        _img.sprite = _pressed;
        //Chạy âm thanh khi bấm nút
        _source.PlayOneShot(_compressClip);
    }
    //Hàm bắt sự kiện khi người chơi thả nút bấm
    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        //Thay đổi hoạt ảnh của nút bấm thành dạng thường
        _img.sprite = _default;
        //Chạy âm thanh khi thả nút
        _source.PlayOneShot(_uncompressClip);
    }
    //Hàm kiểm tra xem người dùng đã bấm chưa
    public void IwasClicked()
    {
        //Nếu AudioListener đang ở trạng thái tạm dừng thì
        if (AudioListener.pause)
        {
            //Hoạt ảnh của nút bấm sẽ ở dạng đã bấm
            _img.sprite = _pressed;
        }
        //Nếu không
        else
        {
            //Hoạt ảnh của nút bấm ở dạng bình thường
            _img.sprite = _default;
        }
    }

}
